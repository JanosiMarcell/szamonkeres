namespace idk.DTO
{
    public class Dto
    {
        public record CreateTargy(Guid Azon, int Jegy, string Leiras, DateTime Letrehozas);
        public record CreateTargyDto(int Jegy, string Leiras, DateTime Letrehozas);

        public record UpdateTargyDto(Guid Azon, int Jegy, string Leiras, DateTime Letrehozas);


    }
}
