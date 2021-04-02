using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Console_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllProducts().Wait();
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine());
            GetProductById(id).Wait();

            Product product = new Product();
            Console.WriteLine("Enter ID");
            product.ProductId = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Name");
            product.Name = (Console.ReadLine());
            Console.WriteLine("Enter Qtyinstock");
            product.QtyInStock =int.Parse(Console.ReadLine());
            Console.WriteLine("ENter description");
            product.Description =(Console.ReadLine());
            Console.WriteLine("ENter supplier");
            product.Supplier = (Console.ReadLine());

            Insert(product).Wait();
            GetAllProducts().Wait();

            Put().Wait();
            GetAllProducts().Wait();

            Delete().Wait();
            GetAllProducts().Wait();

        }


        static async Task GetAllProducts()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Products");
                if (response.IsSuccessStatusCode)
                {

                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    var productList = JsonConvert.DeserializeObject<List<Product>>(jsonString.Result);

                    foreach (var temp in productList)
                    {
                        Console.WriteLine("Id:{0}\tName:{1}", temp.ProductId, temp.Name);





                    }

                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine("Internal server Error");
                }

            }
        }

        static async Task GetProductById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Products/" + id);
                if (response.IsSuccessStatusCode)
                {
                    Product product = await response.Content.ReadAsAsync<Product>();
                    Console.WriteLine("Id:{0}\tName:{1}", product.ProductId, product.Name);
                    //  Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);

                }


            }
        }
        static async Task Insert(Product product)
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:44383/");


                HttpResponseMessage response = await client.PostAsJsonAsync("api/Products", product);

                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.  
                    Console.WriteLine(response.StatusCode);
                }
            }
        }
        static async Task Put()
        {

            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:44383/");

                //PUT Method  
                var department = new Product() { ProductId = 1, Name = "Updated Depart" };
                int id = 1;
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Products/" + id, department);
                if (response.IsSuccessStatusCode)

                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
            }
        }

        static async Task Delete()
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:44383/");


                int id = 1;
                HttpResponseMessage response = await client.DeleteAsync("api/Products/" + id);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                    Console.WriteLine(response.StatusCode);
            }
        }
    }
}