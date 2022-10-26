using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

using Model;

namespace Services;

public class ApiService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public ApiService(HttpClient http, IConfiguration configuration)
    {
        this.http = http;
        this.configuration = configuration;
        this.baseAPI = configuration["base_api"];
    }


    // post actions
    public async Task<Post[]> GetPosts()
    {
        string url = $"https://localhost:7174/api/posts/";
        Console.WriteLine(url);
        return await http.GetFromJsonAsync<Post[]>(url);
    }


    public async Task<Post> GetPost(int id)
    {
        string url = $"https://localhost:7174/api/posts/{id}";
        return await http.GetFromJsonAsync<Post>(url);
    }


    public async Task<Post> CreatePost(string title, string text, string user)
    {
        string url = $"https://localhost:7174/api/posts/";

        HttpResponseMessage msg = await http.PostAsJsonAsync(url, new { title, text, user });

        string json = msg.Content.ReadAsStringAsync().Result;

        Post? newPost = JsonSerializer.Deserialize<Post>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return newPost;
    }


    public async Task<Post> UpvotePost(int id)
    {
        string url = $"https://localhost:7174/api/posts/{id}/upvote/";

        HttpResponseMessage msg = await http.PutAsJsonAsync(url, "");

        string json = msg.Content.ReadAsStringAsync().Result;

        Post? updatedPost = JsonSerializer.Deserialize<Post>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Ignore case when matching JSON properties to C# properties
        });

        return updatedPost;
    }


    public async Task<Post> DownvotePost(int id)
    {
        string url = $"https://localhost:7174/api/posts/{id}/downvote/";

        HttpResponseMessage msg = await http.PutAsJsonAsync(url, "");

        string json = msg.Content.ReadAsStringAsync().Result;

        Post? updatedPost = JsonSerializer.Deserialize<Post>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Ignore case when matching JSON properties to C# properties
        });

        return updatedPost;
    }


    //comment actions
    public async Task<Comment> CreateComment(string CommentText, string CommentUser, int PostId)
    {
        string url = $"https://localhost:7174/api/posts/{PostId}/comments";

        HttpResponseMessage msg = await http.PostAsJsonAsync(url, new { CommentText, CommentUser, PostId });

        string json = msg.Content.ReadAsStringAsync().Result;

        Comment? newComment = JsonSerializer.Deserialize<Comment>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Ignore case when matching JSON properties to C# properties 
        });

        return newComment;
    }


}