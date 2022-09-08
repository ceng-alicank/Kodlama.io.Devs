using Application.Dtos;

namespace Application.Features.Technologies.GetList
{
    public class GetListTechnologyQueryResponse
    {
        public IList<GetListTechnologyDto> Items { get; set; }
    }
}
