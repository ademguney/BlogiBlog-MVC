namespace Blogi.Application.Features.Post.Constants
{
    public static class PostMessages
    {
        public const string GetByIdExists = "Article record exists.";
        public const string GetByIdNotExists = "Article id not exists!";
        public const string GetListExists = "Article exists.";
        public const string GetListNotExists = "Article record not exists!";
        public const string NameExists = "An event with the same name already exists.";
        public const string CreatedSuccess = "Article successfully created.";
        public const string DeletedSuccess = "Article successfully deleted.";
        public const string UpdatedSuccess = "Article successfully updated.";
    }
}