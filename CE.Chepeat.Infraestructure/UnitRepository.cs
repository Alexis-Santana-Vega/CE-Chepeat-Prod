using CE.Chepeat.Infraestructure.Repositories;
using CE.Chepeat.Infraestructure.Services;

namespace CE.Chepeat.Infraestructure;
public class UnitRepository:BaseDisposable, IUnitRepository
{
    private readonly ChepeatContext _context;
    private readonly IConfiguration _configuration;

    public UnitRepository(ChepeatContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    protected override void DisposeManagedResource()
    {
        try
        {
            _context.Dispose();


            //if (_context.Database.GetDbConnection != null)
            //{
            //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().State);
            //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().ConnectionTimeout);
            //}
        }
        finally
        {
            base.DisposeManagedResource();
        }
    }
    //
    public IUserInfraestructure userInfraestructure => new UserInfraestructure(_context);
    public IAuthInfraestructure authInfraestructure => new AuthInfraestructure(_context);
    public ISellerInfraestructure sellerInfraestructure => new SellerInfraestructure(_context);
    public IProductInfraestructure productInfraestructure => new ProductInfraestructure(_context);
    public IPurchaseRequestInfraestructure purchaseRequestInfraestructure => new PurchaseRequestInfraestructure(_context);
    public ITransactionInfraestructure transactionInfraestructure => new TransactionInfraestructure(_context);
    public ICommentInfraestructure commentInfraestructure => new CommentInfraestructure(_context);


    public IEmailServiceInfraestructure emailServiceInfraestructure => new EmailService(_configuration);


    public IFileExportServiceInfraestructure fileExportServiceInfraestructure => new FileService();


    public async ValueTask<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }



    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }

}
