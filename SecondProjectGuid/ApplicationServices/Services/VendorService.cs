using Newtonsoft.Json;
using SecondProjectGuid.ApplicationServices.IServices;
using SecondProjectGuid.DTOs.Histories;
using SecondProjectGuid.DTOs.Tags;
using SecondProjectGuid.DTOs.Vendors;
using SecondProjectGuid.InferaStructure.IRepositories;
using SecondProjectGuid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SecondProjectGuid.ApplicationServices.Services
{
    public class VendorService:IVendorService
    {
        private readonly IVendorRepository _repository;
        private readonly IHistoryRepository _historyRepository;

        public VendorService(IVendorRepository repository, IHistoryRepository historyRepository)
        {
            _repository = repository;
            _historyRepository = historyRepository;
        }

        public async Task<VendorDTO> GetVendorById(string id)
        {
            var data = await _repository.GetVendorById(id);

            var listDTO = data.Tags.Select(x => new TagDTO
            {
                Name = x.Name,
                Value = x.Value
            }).ToList();

            VendorDTO vendorDTO = new VendorDTO
            {
                Name = data.Name,
                Title = data.Title,
                Date = data.Date,
                Tags = listDTO
            };

            return vendorDTO;
        }
        public async Task<bool> DeleteVendorById(string id)
        {
            bool deleted = false;

             using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            //var deleteVendor = await _repository.GetVendorById(id);
            var deleteVendor = await _repository.DeleteById(id);

            if (deleteVendor != null)
            {
                deleted = true;
            }

            var vendorDeleteDTO = new VendorUpdateDTO
            {
                Id = deleteVendor.Id,
                Name = deleteVendor.Name,
                Title = deleteVendor.Title,
                Date = deleteVendor.Date
            };
            string json = JsonConvert.SerializeObject(vendorDeleteDTO);

            var history = new History()
            {
                VendorId = vendorDeleteDTO.Id,
                Operation = "Delete",
                JsonResult = json,
            };
           // var delete = await _repository.DeleteById(deleteVendor, history);
           
             await _historyRepository.Insert(history);
            scope.Complete();
            return deleted;
        }
        public async Task<int> Update(VendorUpdateDTO DTO, string Id)
        {
            var list = new List<Tag>();
            foreach (var item in DTO.Tags)
            {
                Tag tag = new Tag
                {
                    Name = item.Name,
                    Value = item.Value
                };
                list.Add(tag);
            }

            // using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var ven = await _repository.GetVendorById(Id);
            ven.Name = DTO.Name;
            ven.Title = DTO.Title;
            ven.Date = DTO.Date;
            ven.Tags = list;

            var vendorUpdateDTO = new VendorUpdateDTO
            {
                Id = ven.Id,
                Name = ven.Name,
                Title = ven.Title,
                Date = ven.Date,
                Tags = ven.Tags.Select(x => new TagDTO
                {
                    Name = x.Name,
                    Value = x.Value

                }).ToList()
            };

            string json = JsonConvert.SerializeObject(vendorUpdateDTO);

            var history = new History()
            {
                VendorId = vendorUpdateDTO.Id,
                Operation = "Put",
                JsonResult = json,
            };

            //await _historyRepository.Insert(history);

            var updateVendor = await _repository.Update(ven, history);

            // scope.Complete();

            return updateVendor;
        }
        public async Task<VendorInsertResponseDTO> Insert(VendorInsertDTO dto)
        {
            string Id = Guid.NewGuid().ToString();
            var tagList = new List<Tag>();
            if (dto.Tags != null && dto.Tags.Count > 0)
            {
                foreach (var Tag in dto.Tags)
                {
                    var tag = new Tag()
                    {
                        Name = Tag.Name,
                        Value = Tag.Value
                    };
                    tagList.Add(tag);
                }
            }
            VendorHistoryDTO vendorHistoryDTO = new VendorHistoryDTO()
            {
                Id = Id,
                Name = dto.Name,
                Title = dto.Title,
                Date = dto.Date,
                Tags = dto.Tags.Select(x => new TagDTO
                {
                    Name = x.Name,
                    Value = x.Value

                }).ToList()
            };
            string json = JsonConvert.SerializeObject(vendorHistoryDTO);
            var historyList = new List<History>();

            var history = new History()
            {
                VendorId = Id,
                Operation = "Post",
                JsonResult = json,
            };
            historyList.Add(history);
            var vendor = new Vendor()
            {
                Id = Id,
                Name = dto.Name,
                Title = dto.Title,
                Date = dto.Date,
                Tags = tagList,
                Histories = historyList
            };

            var vendorResult = await _repository.Insert(vendor);

            VendorInsertResponseDTO vendorResponseDTO = new VendorInsertResponseDTO()
            {
                Id = vendorResult.Id,
                Name = vendorResult.Name,
                Title = vendorResult.Title,
                Date = vendorResult.Date,
                Tags = vendorResult.Tags.Select(x => new TagDTO
                {
                    Name = x.Name,
                    Value = x.Value

                }).ToList(),
                Histories = vendorResult.Histories.Select(y => new HistoryDTO
                {
                    JsonResult = y.JsonResult,
                    Operation = y.Operation,


                }).ToList()

            };
            return vendorResponseDTO;
        }
    }
}
