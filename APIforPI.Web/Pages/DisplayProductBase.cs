using APIforPI.Infrastracture.Dto;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace APIforPI.Web.Pages
{
    public class DisplayProductBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
        [Parameter]
        public CultureInfo culture { get; set; }
    }
}
