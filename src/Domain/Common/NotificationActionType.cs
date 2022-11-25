namespace Domain.Common
{
    /// <summary>
    ///
    /// </summary>
    public enum NotificationActionType
    {
        /// <summary>
        /// The undefined
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// The asset created
        /// </summary>
        AssetCreated = 100,

        /// <summary>
        /// The asset edited
        /// </summary>
        AssetEdited = 101,

        /// <summary>
        /// The asset deleted
        /// </summary>
        AssetDeleted = 102,

        /// <summary>
        /// The asset check out
        /// </summary>
        AssetCheckOut = 103,

        /// <summary>
        /// The asset check in
        /// </summary>
        AssetCheckIn = 104,

        /// <summary>
        /// The asset reserved
        /// </summary>
        AssetReserved = 105,

        /// <summary>
        /// The asset service
        /// </summary>
        AssetService = 106,

        /// <summary>
        /// The asset reservation extended
        /// </summary>
        AssetReservationExtended = 107,

        /// <summary>
        /// The asset check out extended
        /// </summary>
        AssetCheckOutExtended = 108,

        /// <summary>
        /// The asset retired
        /// </summary>
        AssetRetired = 109,

        /// <summary>
        /// The asset service completed
        /// </summary>
        AssetServiceCompleted = 110,
        /// <summary>
        /// 
        /// </summary>
        AssetCheckOutDisbursed = 111,
        /// <summary>
        /// 
        /// </summary>
        AssetReservationDisbursed = 112,

        /// <summary>
        /// 
        /// </summary>
        AssetDisposal = 113,
        /// <summary>
        /// 
        /// </summary>
        StockCreated = 200,

        /// <summary>
        /// The contract created
        /// </summary>
        ContractCreated = 300,
        /// <summary>
        /// 
        /// </summary>
        UserCreated = 400,
        /// <summary>
        /// 
        /// </summary>
        EmployeeCreated = 401,
        /// <summary>
        /// The password reset
        /// </summary>
        PasswordReset = 410,
        /// <summary>
        /// 
        /// </summary>
        IdleAsset = 1000,
        /// <summary>
        /// 
        /// </summary>
        OverDueAssets = 1100
    }
}