using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
	public class BrandManager : IBrandService
	{
		private readonly IBrandDal _brandDal;
		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
		{
			//business rules

			//mapping --> automapper
			Brand brand = new();
			brand.Name = createBrandRequest.Name;
			brand.CreatedTime = DateTime.Now;

			_brandDal.Add(brand);

			//mapping
			CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
			createdBrandResponse.Name = brand.Name;
			createdBrandResponse.Id = 1;
			createdBrandResponse.CreatedTime = brand.CreatedTime;

			return createdBrandResponse;
		}

		public List<GetAllBrandResponse> GetAll()
		{
			List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();
			
			foreach (var brand in _brandDal.GetAll())
			{
				GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
				getAllBrandResponse.Name=brand.Name;
				getAllBrandResponse.Id = brand.Id;
				getAllBrandResponse.CreatedTime= brand.CreatedTime;
				getAllBrandResponses.Add(getAllBrandResponse);
			}

			return getAllBrandResponses;
		}
	}
}
