using BasicClean.Api.Integration.Test.Helpers;
using BasicClean.Core.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BasicClean.Api.Integration.Test
{
    public class TodoControllerTest: IClassFixture<TestStartup<Startup>>
    {
       readonly HttpClient _httpClient;
        public TodoControllerTest(TestStartup<Startup> testSturtup)
        {
            _httpClient = testSturtup.CreateClient();
        }

        [Fact]
        public async Task TodoList_ShoultNotBeEmpty_WhenGetAll()
        {
            var httpResponse = await _httpClient.GetAsync("api/todos");
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IEnumerable<TodoItemDto>>(stringResponse);
            Assert.True(response.Count() > 0, "The todos count was not greater than 0");

        }
    }
}
