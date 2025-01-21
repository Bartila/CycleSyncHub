using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CycleSyncHub.Application.Bike.Queries.GetBikeByEncodedName
{
	public class GetBikeByEncodedNameQuery : IRequest<BikeDto>
	{
		public string EncodedName { get; set; }

		public GetBikeByEncodedNameQuery(string encodedName)
		{
			EncodedName = encodedName;
		}
	}
}
