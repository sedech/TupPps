﻿using AutoMapper;
using BusnessService.IService;
using BussnessEntities;
using DataModels.Entities;
using DataModels.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.Service
{
    public class BrandService : IBrandService
    {
           private readonly IBrandRepository _repo;
           private readonly IMapper _maapper;

        public BrandService(IBrandRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }

        public async Task<Int64> Create(BrandToCreateBe entity)
        {
            var result = _maapper.Map<Brand>(entity);
            return await _repo.Create(result);
        }


        public async Task<BrandBe> GetById(int id)
        {
            return _maapper.Map<BrandBe>(await _repo.GetById(id));
        }

        public async Task<bool> Update(BrandBe entity)
        {
            var result = _maapper.Map<Brand>(entity);
            return await _repo.Update(result);

        }

        public async Task<IEnumerable<BrandBe>> GetAll()
        {
            var brands = await _repo.GetAll();
            return _maapper.Map<IEnumerable<BrandBe>>(brands);
        }


    }
}
