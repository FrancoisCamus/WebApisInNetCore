namespace GrpcApi.Mappers
{
    public class DtoToEntityMapper
    {
         public static Shared.Entities.Author MapAuthor(Author source)
        {
            var dest = new Shared.Entities.Author();
            dest.Id = source.Id;
            dest.Bio = source.Bio;
            dest.Name = source.Name;
            return dest;
        }

    }
}
