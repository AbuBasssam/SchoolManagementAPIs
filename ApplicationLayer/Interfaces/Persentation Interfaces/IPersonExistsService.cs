namespace ApplicationLayer.Interfaces
{
    public interface IPersonExistsService
    {
        public Task<bool> IsExistsByNationalNo(string NationalNo);

    }
}
