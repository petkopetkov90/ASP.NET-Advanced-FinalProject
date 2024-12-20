using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.OrderConstants;
using static FleetRouteManager.Common.ErrorMessages.OrderErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.OrderInputModels
{
    public class OrderCreateInputModel
    {
        [Required(ErrorMessage = OrderNumberRequiredMsg)]
        [StringLength(OrderNumberMaxLength, MinimumLength = OrderNumberMinLength, ErrorMessage = OrderNumberLengthMsg)]
        [RegularExpression(OrderNumberFormatRegex, ErrorMessage = OrderNumberFormatMsg)]
        public string OrderNumber { get; set; } = null!;

        [Required(ErrorMessage = OrderDateRequiredMsg)]
        [RegularExpression(OrderDateFormatRegex, ErrorMessage = OrderDateFormatMsg)]
        public string OrderDate { get; set; } = null!;

        [Required(ErrorMessage = OrderAmountRequiredMsg)]
        [Range(OrderAmountMin, OrderAmountMax, ErrorMessage = OrderAmountRangeMsg)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = OrderUserNameRequiredMsg)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = OrderUserNameLengthMsg)]
        [RegularExpression(UserNameFormatRegex, ErrorMessage = OrderUserNameFormatMsg)]
        public string User { get; set; } = null!;

        [Required(ErrorMessage = OrderClientRequiredMsg)]
        public int ClientId { get; set; }
    }
}
