namespace EliteFlex.Web;

public class TaskApiClient(HttpClient httpClient)
{
    public async Task<FlexTask[]> GetTasksAsync()
    {
        return await httpClient.GetFromJsonAsync<FlexTask[]>("/task") ?? []
        ;
    }
}

public record FlexTask(string Title, int id)
{
   
}