﻿using AutoMapper;

using MicroServiceTest.Services.CouponAPI.Data;

using MicroServiceTest.Services.CouponAPI.Models;

using MicroServiceTest.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Mango.Services.CouponAPI.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    public class CouponAPIController : ControllerBase

    {

        private readonly AppDbContext _db;

        private ResponseDTO _response;

        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)

        {

            _db = db;

            _mapper = mapper;
            _response = new ResponseDTO();

        }

        [HttpGet]

        public ResponseDTO Get()

        {

            try

            {

                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);

            }

            catch (Exception ex)

            {

                _response.IsSuccess = false;

                _response.Message = ex.Message;

            }

            return _response;

        }

        [HttpGet]

        [Route("{id:int}")]

        public ResponseDTO Get(int id)

        {

            try

            {

                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDTO>(obj);

            }

            catch (Exception ex)

            {

                _response.IsSuccess = false;

                _response.Message = ex.Message;

            }

            return _response;

        }
        [HttpGet]

        [Route("GetByCode/{code}")]

        public ResponseDTO GetByCode(string code)
        {

            try

            {

                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());

                _response.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;

                _response.Message = ex.Message;
            }

            return _response;

        }

    }

}


