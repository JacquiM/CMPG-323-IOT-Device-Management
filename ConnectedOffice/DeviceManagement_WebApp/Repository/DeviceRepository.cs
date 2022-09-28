using System;

public class DeviceRepository
{
	ConnectedOfficeContext _context = new ConnectedOfficeContext();
	public DeviceRepository()
	{
		public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
        }

	}
}
