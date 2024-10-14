namespace idk.DTO
{
    public class Dto
    {
        public record CreateTargy(Guid Id, string targy, int ar);
        public record CreateTargyDto(string targy, int ar);

        public record UpdateTargyDto(Guid Id, string targy, int ar);


    }
}
