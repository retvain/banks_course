namespace banks_course.Services.Parsers;

public class BaseParser
{
    protected string? SourceUrl;
    
    protected async Task<string> GetResponse(DateTime date)
    {
        using var client = new HttpClient();
        
        var url = SourceUrl + date.ToString("yyyy-MM-dd");
        var response = await client.GetStringAsync(url);

        return response;
    }
}