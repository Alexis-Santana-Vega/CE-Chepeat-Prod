namespace CE.Chepeat.Application.Interfaces.Controllers;
public interface IApiController
{
    IUserPresenter UserPresenter { get; }
    IAuthPresenter AuthPresenter { get; }
    ISellerPresenter SellerPresenter { get; }
    IProductPresenter ProductPresenter { get; }
    IPurchaseRequestPresenter PurchaseRequestPresenter { get; }
    ITransactionPresenter TransactionPresenter { get; }
    ICommentPresenter CommentPresenter { get; }

    IFileExportPresenter FileExportPresenter { get; }
}
