

using APIforPI.Infrastracture.Dto;
using System.Net.Http.Json;

List<ProductDto> products = new List<ProductDto>();
HttpClient HttpClient= new HttpClient();
products = (List<ProductDto>)await HttpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
foreach (var item in products)
{
    Console.WriteLine(item.Name);
}