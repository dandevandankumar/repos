﻿using FileUploadApi.Requests;
using FileUploadApi.Response;

namespace FileUploadApi.Interfaces
{
    public interface IPostService
    {
        Task SavePostImageAsync(PostRequest postRequest);
        Task<PostResponse> CreatePostAsync(PostRequest postRequest);
        Task GetPostByIdAsync(int id);
        object GetAllPosts();
        Task GetAllPostsAsync();
    }
}