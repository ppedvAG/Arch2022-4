namespace ppedv.Hotelity.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();
            
            var result =  con.Database.EnsureCreated();

            Assert.True(result);
        }
    }
}