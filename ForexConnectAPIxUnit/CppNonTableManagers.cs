using System;
using Xunit;
using Xunit.Abstractions;

namespace ForexConnect
{
    public class CppNonTableManagers : Parameter
    {
        public CppNonTableManagers(ITestOutputHelper output) : base(output)
        {
            this.output = output;
        }

        string PATH_CREATE_OTO = @"cpp\NonTableManagerSamples\CreateOTO";
        string PATH_CLOSE_POSITION = @"cpp\NonTableManagerSamples\ClosePosition";
        string PATH_OPEN_POSITION = @"cpp\NonTableManagerSamples\OpenPosition";
        string PATH_CLOSE_ALL_POSITION = @"cpp\NonTableManagerSamples\CloseAllPositions";
        string PATH_CHECK_PERMISIONS = @"cpp\NonTableManagerSamples\CheckPermissions";
        string PATH_CREATE_ENTRY = @"cpp\NonTableManagerSamples\CreateEntry";
        string PATH_CREATE_ELS = @"cpp\NonTableManagerSamples\CreateELS";
        string PATH_CREATE_OCO = @"cpp\NonTableManagerSamples\CreateOCO";
        string PATH_CREATE_AND_FIND_ENTRY = @"cpp\NonTableManagerSamples\CreateAndFindEntry";
        string PATH_CREATE_ORDER_BY_SYMBOL = @"cpp\NonTableManagerSamples\CreateOrderBySymbol";
        string PATH_CREATE_OTOCO = @"cpp\NonTableManagerSamples\CreateOTOCO";
        string PATH_LOGIN = @"cpp\NonTableManagerSamples\Login";
        string PATH_GET_LAST_UPDATE_ORDER = @"cpp\NonTableManagerSamples\GetLastOrderUpdate";
        string PATH_IF_THEN = @"cpp\NonTableManagerSamples\If-then";
        string PATH_PARTIAL_FILL = @"cpp\NonTableManagerSamples\PartialFill";
        string PATH_PRINT_TABLE = @"cpp\NonTableManagerSamples\PrintTable";
        string PATH_REMOVE_ORDER = @"cpp\NonTableManagerSamples\RemoveOrder";
        string PATH_SAMPLE_COMISSION_DETAIL = @"cpp\NonTableManagerSamples\ShowCommissionDetails";
        string PATH_TRADING_SETTING = @"cpp\NonTableManagerSamples\TradingSettings";
        string PATH_TWO_CONNECTION = @"cpp\NonTableManagerSamples\TwoConnections";
        string PATH_GET_OFFERS = @"cpp\TableManagerSamples\GetOffers";
        string PATH_CLOSE_ALL_POSTION_BY_INSTRUMENT = @"cpp\TableManagerSamples\CloseAllPositionsByInstrument";
        string PATH_CALCULATE_TRADING_COMMISSION = @"cpp\NonTableManagerSamples\CalculateTradingCommissions";
        string PATH_SEARCH_IN_TABLE = @"cpp\NonTableManagerSamples\SearchInTable";
        string PATH_REMOVE_FROM_GROUP = @"cpp\NonTableManagerSamples\RemoveFromGroup";
        string PATH_JOIN_NEW_GROUP = @"cpp\NonTableManagerSamples\JoinNewGroup";
        string PATH_JOIN_EXISTING_GROUP = @"cpp\NonTableManagerSamples\JoinExistingGroup";
        string PATH_OPEN_POSITION_NETTING = @"cpp\NonTableManagerSamples\OpenPositionNetting";
        string PATH_NET_STOP_LIMIT = @"cpp\NonTableManagerSamples\NetStopLimit";
        string PATH_GET_HIST_PRICE = @"cs\netcore1.0\NonTableManagerSamples\GetHistPrices";

        private readonly ITestOutputHelper output;

        private void CheckPermisions(string result)
        {
            string canCreateMarketOpenOrder =
                "canCreateMarketOpenOrder = Permission Enabled";
            string canDeleteMarketOpenOrder =
                "canDeleteMarketOpenOrder = Permission Enabled";
            string canCreateEntryOrder =
                "canCreateEntryOrder = Permission Enabled";
            string canChangeEntryOrder =
                "canChangeEntryOrder = Permission Enabled";
            string canDeleteEntryOrder =
                "canDeleteEntryOrder = Permission Enabled";
            string doneSampleMessange = "Done!";

            Assert.True(result.Contains(canCreateMarketOpenOrder),
                "not contain line - " + canCreateMarketOpenOrder);
            Assert.True(result.Contains(canDeleteMarketOpenOrder),
                "not contain line - " + canDeleteMarketOpenOrder);
            Assert.True(result.Contains(canCreateEntryOrder),
                "not contain line - " + canCreateEntryOrder);
            Assert.True(result.Contains(canChangeEntryOrder),
                "not contain line - " + canChangeEntryOrder);
            Assert.True(result.Contains(canDeleteEntryOrder),
                "not contain line - " + canDeleteEntryOrder);
            Assert.True(result.Contains(doneSampleMessange),
                "not contain line - " + doneSampleMessange);
            CheckError(result);
        }

        [Fact]
        public void Cpp_NonTable_CheckPermisionsAccount_Y()
        {
            CMD(PATH_CHECK_PERMISIONS, CLEAN_BAT);
            CMD(PATH_CHECK_PERMISIONS, BUILD_BAT);
            string result = CMD(PATH_CHECK_PERMISIONS,
                RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
            CheckPermisions(result);
            CMD(PATH_CHECK_PERMISIONS, CLEAN_BAT);
        }

        //private void CheckCreateOCO(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID=";
        //    string typeFirst = "Type='SE', BuySell='B', Rate=";
        //    string timeInForce = "TimeInForce='GTC'";
        //    string typeSecond = "Type='SE', BuySell='S', Rate=";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(typeFirst),
        //        "not contain line - " + typeFirst);
        //    Assert.True(result.Contains(timeInForce),
        //        "not contain line - " + timeInForce);
        //    Assert.True(result.Contains(typeSecond),
        //        "not contain line - " + typeSecond);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_Create_OCO_Account_Y()
        //{
        //    CMD(PATH_CREATE_OCO, CLEAN_BAT);
        //    CMD(PATH_CREATE_OCO, BUILD_BAT);
        //    string result = CMD(PATH_CREATE_OCO,
        //        RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
        //    CheckCreateOCO(result);
        //    CMD(PATH_CREATE_OCO, CLEAN_BAT);
        //}

        //private void CheckCreateEntry(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID=";
        //    string dataOrder =
        //        "Type='LE', BuySell='B', Rate='0.9', TimeInForce='GTC'";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(dataOrder),
        //        "not contain line - " + dataOrder);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_Create_Entry_Account_Y()
        //{
        //    CMD(PATH_CREATE_ENTRY, CLEAN_BAT);
        //    CMD(PATH_CREATE_ENTRY, BUILD_BAT);
        //    string result = CMD(PATH_CREATE_ENTRY,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);
        //    CheckCreateEntry(result);
        //    CMD(PATH_CREATE_ENTRY, CLEAN_BAT);
        //}

        //private void CheckCreateELS(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID=";
        //    string dataOrder = "Type='LE', BuySell='B', Rate=";
        //    string timeInForce = "TimeInForce='GTC'";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(dataOrder),
        //        "not contain line - " + dataOrder);
        //    Assert.True(result.Contains(timeInForce),
        //        "not contain line - " + timeInForce);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_Create_ELS_Account_Y()
        //{
        //    CMD(PATH_CREATE_ELS, CLEAN_BAT);
        //    CMD(PATH_CREATE_ELS, BUILD_BAT);
        //    string result = CMD(PATH_CREATE_ELS,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    CheckCreateELS(result);
        //    CMD(PATH_CREATE_ELS, CLEAN_BAT);
        //}

        //private void CheckCreateOTO(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID=";
        //    string forFirstCreateOrder = "Type='SE', BuySell='S', Rate=";
        //    string forSecondCreateOrder = "Type='SE', BuySell='B', Rate=";
        //    string timeForce = "TimeInForce='GTC'";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(forFirstCreateOrder),
        //        "not contain line - " + forFirstCreateOrder);
        //    Assert.True(result.Contains(forSecondCreateOrder),
        //        "not contain line - " + forSecondCreateOrder);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_CreateOTO_Account_Y()
        //{
        //    CMD(PATH_CREATE_OTO, CLEAN_BAT);
        //    CMD(PATH_CREATE_OTO, BUILD_BAT);
        //    string result = CMD(PATH_CREATE_OTO,
        //        RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
        //    CheckCreateOTO(result);
        //    CMD(PATH_CREATE_OTO, CLEAN_BAT);
        //}

        //private void CheckOpenPosition(string result, int amount)
        //{
        //    string nameSample = "Running OpenPosition with arguments:";
        //    string orderAdded = "The order has been added. OrderID='";
        //    string timeForce = "TimeInForce='IOC'";
        //    string orderDeleted =
        //        "The order has been deleted. OrderID=";
        //    string amountAcc = "Amount: " + amount;
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(nameSample),
        //        "not contain line - " + nameSample);
        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);
        //    Assert.True(result.Contains(orderDeleted),
        //        "not contain line - " + orderDeleted);
        //    Assert.True(result.Contains(amountAcc),
        //        "not contain line - " + amountAcc);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_OpenPosition_Account_Y()
        //{
        //    CMD(PATH_OPEN_POSITION, CLEAN_BAT);
        //    CMD(PATH_OPEN_POSITION, BUILD_BAT);
        //    string result = CMD(PATH_OPEN_POSITION,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    CheckOpenPosition(result, AMOUNT_Y);
        //    CMD(PATH_OPEN_POSITION, CLEAN_BAT);
        //}

        //private void CheckClosePosition(string result, int amount)
        //{
        //    string balanceChanged = "The balance has been changed";
        //    string orderAdded =
        //        "The order has been added. OrderID=";
        //    string timeForce = "TimeInForce='IOC'";
        //    string orderDeleted =
        //        "The order has been deleted. OrderID=";
        //    string closeTrade = "Closed Trade ID:";
        //    string amountAcc = "Amount: " + amount;
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(balanceChanged),
        //        "not contain line - " + balanceChanged);
        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);
        //    Assert.True(result.Contains(orderDeleted),
        //        "not contain line - " + orderDeleted);
        //    Assert.True(result.Contains(closeTrade),
        //        "not contain line - " + closeTrade);
        //    Assert.True(result.Contains(amountAcc),
        //        "not contain line - " + amountAcc);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_SR_ClosePosition_Account_Y()
        //{
        //    CMD(PATH_CLOSE_POSITION, CLEAN_BAT);
        //    CMD(PATH_CLOSE_POSITION, BUILD_BAT);
        //    CMD(PATH_OPEN_POSITION, BUILD_BAT);
        //    CMD(PATH_OPEN_POSITION,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    string result = CMD(PATH_CLOSE_POSITION,
        //        RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
        //    CheckClosePosition(result, AMOUNT_Y);
        //    CheckError(result);
        //    CMD(PATH_CLOSE_POSITION, CLEAN_BAT);
        //}

        //private void CheckCloseAllPosition(string result, int amount)
        //{
        //    string nameSample = "Running CloseAllPositions with arguments:";
        //    string orderAdded =
        //        "The order has been added. OrderID='";
        //    string timeForce = "TimeInForce='IOC'";
        //    string orderDeleted =
        //        "The order has been deleted. OrderID=";
        //    string forTheOrder = "For the order: OrderID=";
        //    string closedTradeID = "Closed Trade ID:";
        //    string amountText = "Amount: " + amount + ",";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(nameSample),
        //        "not contain line - " + nameSample);
        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);
        //    Assert.True(result.Contains(orderDeleted),
        //        "not contain line - " + orderDeleted);
        //    Assert.True(result.Contains(forTheOrder),
        //        "not contain line - " + forTheOrder);
        //    Assert.True(result.Contains(closedTradeID),
        //        "not contain line - " + closedTradeID);
        //    Assert.True(result.Contains(amountText),
        //        "not contain line - " + amountText);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_SR_CloseAllPosition_Account_Y()
        //{
        //    CMD(PATH_CLOSE_ALL_POSITION, CLEAN_BAT);
        //    CMD(PATH_CLOSE_ALL_POSITION, BUILD_BAT);
        //    CMD(PATH_OPEN_POSITION, BUILD_BAT);
        //    CMD(PATH_OPEN_POSITION, RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    string result = CMD(PATH_CLOSE_ALL_POSITION, RUN_PARAMETR_Y_ACCOUNT);
        //    CheckCloseAllPosition(result, AMOUNT_Y);
        //    CMD(PATH_CLOSE_ALL_POSITION, CLEAN_BAT);
        //}


        //private void CheckCreateAndFindEntry(string result, int amount)
        //{
        //    string order = "Your order ID is";
        //    string amountText = "Amount='" + amount;
        //    string successfullyCreated =
        //        "You have successfully created an entry order for instrument EUR/USD";
        //    string typeOrder = "Type='LE', BuySell='B',";
        //    string status = "Type='LE', Status='W', OfferID='1'";
        //    string timeForce = "TimeInForce='GTC'";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(order),
        //        "not contain line - " + order);
        //    Assert.True(result.Contains(amountText),
        //        "not contain line - " + amountText);
        //    Assert.True(result.Contains(successfullyCreated),
        //        "not contain line - " + successfullyCreated);
        //    Assert.True(result.Contains(typeOrder),
        //        "not contain line - " + typeOrder);
        //    Assert.True(result.Contains(status),
        //        "not contain line - " + status);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_CreateAndFindEntry_Account_Y()
        //{
        //    CMD(PATH_CREATE_AND_FIND_ENTRY, CLEAN_BAT);
        //    CMD(PATH_CREATE_AND_FIND_ENTRY, BUILD_BAT);
        //    string result = CMD(PATH_CREATE_AND_FIND_ENTRY,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    CheckCreateAndFindEntry(result, AMOUNT_Y);
        //    CMD(PATH_CREATE_AND_FIND_ENTRY, CLEAN_BAT);
        //}

        //private void CheckCreateOrderBySymbol(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID='";
        //    string typeOrder = "Instrument='EUR/USD', BuySell='B', Rate='0.9', Lots='1'";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(typeOrder),
        //        "not contain line - " + typeOrder);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_CreateOrderBySymbol_Account_Y()
        //{
        //    CMD(PATH_CREATE_ORDER_BY_SYMBOL, CLEAN_BAT);
        //    CMD(PATH_CREATE_ORDER_BY_SYMBOL, BUILD_BAT);
        //    string result = CMD(PATH_CREATE_ORDER_BY_SYMBOL,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);
        //    CheckCreateOrderBySymbol(result);
        //    CMD(PATH_CREATE_ORDER_BY_SYMBOL, CLEAN_BAT);
        //}

        //private void CheckCreateOTOCO(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID=";
        //    string typeFirst = "Type='SE', BuySell='S', Rate='1.2'";
        //    string timeInForce = "TimeInForce='GTC'";
        //    string typeSecond =
        //        "Type='SE', BuySell='B', Rate='1.2', TimeInForce='GTC'ContType='4'";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(typeFirst),
        //        "not contain line - " + typeFirst);
        //    Assert.True(result.Contains(timeInForce),
        //        "not contain line - " + timeInForce);
        //    Assert.True(result.Contains(typeSecond),
        //        "not contain line - " + typeSecond);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_CreateOTOCO_Account_Y()
        //{
        //    CMD(PATH_CREATE_OTOCO, CLEAN_BAT);
        //    CMD(PATH_CREATE_OTOCO, BUILD_BAT);
        //    string result = CMD(PATH_CREATE_OTOCO,
        //        RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
        //    CheckCreateOTOCO(result);
        //    CMD(PATH_CREATE_OTOCO, CLEAN_BAT);
        //}

        //private void CheckLogin(string result, int accountID)
        //{
        //    string account = "AccountID: " + accountID;
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(account),
        //         "not contain line - " + account);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_Login_01_Account_Y()
        //{
        //    CMD(PATH_LOGIN, CLEAN_BAT);
        //    CMD(PATH_LOGIN, BUILD_BAT);
        //    string result = CMD(PATH_LOGIN,
        //        RUN_PARAMETR_Y_ACCOUNT);
        //    CheckLogin(result, ACCOUNT_ID_Y);
        //}

        //[Fact]
        //public void Cpp_NonTable_Login_02_Account_F()
        //{
        //    string result = CMD(PATH_LOGIN,
        //        RUN_PARAMETR_F_ACCOUNT);
        //    CheckLogin(result, ACCOUNT_ID_F);
        //}

        //[Fact]
        //public void Cpp_NonTable_Login_03_Account_F_MULTY()
        //{
        //    string result = CMD(PATH_LOGIN,
        //        RUN_PARAMETR_F_MULTY_ACCOUNT);
        //    CheckLogin(result, ACCOUNT_ID_F_MULTY);
        //}

        //[Fact]
        //public void Cpp_NonTable_Login_04_Account_N()
        //{
        //    string result = CMD(PATH_LOGIN,
        //        RUN_PARAMETR_N_ACCOUNT);
        //    CMD(PATH_LOGIN, CLEAN_BAT);
        //    CheckLogin(result, ACCOUNT_ID_N);
        //}

        //private void CheckGetLastUpdateOrder(string result)
        //{
        //    string createdTrueMarket = "The order has been added. OrderID=";
        //    string lastOrderUpdate = "Type='OM', BuySell='B', Rate='1.2', TimeInForce='IOC'";
        //    string status = "Status='F', StatusTime=";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(createdTrueMarket),
        //        "not contain line - " + createdTrueMarket);
        //    Assert.True(result.Contains(lastOrderUpdate),
        //        "not contain line - " + lastOrderUpdate);
        //    Assert.True(result.Contains(status),
        //        "not contain line - " + status);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_GetLastUpdateOrder_Account_Y()
        //{
        //    CMD(PATH_GET_LAST_UPDATE_ORDER, CLEAN_BAT);
        //    CMD(PATH_GET_LAST_UPDATE_ORDER, BUILD_BAT);
        //    string result = CMD(PATH_GET_LAST_UPDATE_ORDER,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    CheckGetLastUpdateOrder(result);
        //    CMD(PATH_GET_LAST_UPDATE_ORDER, CLEAN_BAT);
        //}


        //private void CheckIfThen(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID=";
        //    string orderTypeFirst = "Type='SE', BuySell='S', Rate='1.2', TimeInForce='GTC'";
        //    string orderTypeSecond = "Type='SE', BuySell='B', Rate='1.2', TimeInForce='GTC'";
        //    string timeForce = "TimeInForce='GTC'";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(orderTypeFirst),
        //        "not contain line - " + orderTypeFirst);
        //    Assert.True(result.Contains(orderTypeSecond),
        //        "not contain line - " + orderTypeSecond);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_IfThen_Account_Y()
        //{
        //    CMD(PATH_IF_THEN, CLEAN_BAT);
        //    CMD(PATH_IF_THEN, BUILD_BAT);
        //    string result = CMD(PATH_IF_THEN,
        //        RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
        //    CheckIfThen(result);
        //    CMD(PATH_IF_THEN, CLEAN_BAT);
        //}

        //private void CheckPartialFill(string result, int accountID)
        //{
        //    string newOrderAdded = "The order has been added. Order ID:";
        //    string account = "Account: " + accountID;
        //    string position = "The position has been opened. TradeID='";
        //    string balanceChange = "The balance has been changed. AccountID=" + accountID;
        //    string orderRemoved = "An order is going to be removed: OrderID='";
        //    string infoThree = "Status='F', Amount='0', OriginAmount='";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(newOrderAdded),
        //        "not contain line - " + newOrderAdded);
        //    Assert.True(result.Contains(account),
        //        "not contain line - " + account);
        //    Assert.True(result.Contains(position),
        //        "not contain line - " + position);
        //    Assert.True(result.Contains(balanceChange),
        //        "not contain line - " + balanceChange);
        //    Assert.True(result.Contains(orderRemoved),
        //        "not contain line - " + orderRemoved);
        //    Assert.True(result.Contains(infoThree),
        //        "not contain line - " + infoThree);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_PartialFill_Account_Y()
        //{
        //    CMD(PATH_PARTIAL_FILL, CLEAN_BAT);
        //    CMD(PATH_PARTIAL_FILL, BUILD_BAT);
        //    string result = CMD(PATH_PARTIAL_FILL,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    CheckPartialFill(result, ACCOUNT_ID_Y);
        //    CMD(PATH_PARTIAL_FILL, CLEAN_BAT);
        //}

        //private void CheckPrintTable(string result, int accountID, int amount)
        //{
        //    string account = "Account: " + accountID;
        //    string orderTable = "Orders table for account " + accountID;
        //    string statusOrder = "Status:'W', Amount:'" + amount;
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(account),
        //        "not contain line - " + account);
        //    Assert.True(result.Contains(orderTable),
        //        "not contain line - " + orderTable);
        //    Assert.True(result.Contains(statusOrder),
        //        "not contain line - " + statusOrder + "or not open orders");
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_PrintTable_Account_Y()
        //{
        //    CMD(PATH_PRINT_TABLE, CLEAN_BAT);
        //    CMD(PATH_PRINT_TABLE, BUILD_BAT);
        //    string result = CMD(PATH_PRINT_TABLE,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    CheckPrintTable(result, ACCOUNT_ID_Y, AMOUNT_Y);
        //}

        //private void CheckRemoveOrder(string result)
        //{
        //    string orderAdded = "The order has been added. OrderID='";
        //    string typeOrder = "Type='LE', BuySell='B', Rate='1.2', TimeInForce='GTC'";
        //    string orderDelete = "The order has been deleted. OrderID='";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(typeOrder),
        //        "not contain line - " + typeOrder);
        //    Assert.True(result.Contains(orderDelete),
        //        "not contain line - " + orderDelete);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_RemoveOrder_Account_Y()
        //{
        //    CMD(PATH_REMOVE_ORDER, CLEAN_BAT);
        //    CMD(PATH_REMOVE_ORDER, BUILD_BAT);
        //    string result = CMD(PATH_REMOVE_ORDER,
        //        RUN_PARAMETR_Y_ACCOUNT);
        //    CheckRemoveOrder(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_SHOW_COMMISSION_DETAIL()
        //{
        //    CMD(PATH_SAMPLE_COMISSION_DETAIL, CLEAN_BAT);
        //    CMD(PATH_SAMPLE_COMISSION_DETAIL, BUILD_BAT);
        //    string result = CMD(PATH_SAMPLE_COMISSION_DETAIL,
        //        RUN_PARAMETR_FOR_SAMPLE_COMISSIONS);
        //    CMD(PATH_SAMPLE_COMISSION_DETAIL, CLEAN_BAT);

        //    string comissionFirst = "Commission 1: AnyDealCommission, CommissionPerTrade";
        //    string comissionsSecond = "Commission 2: AnyDealCommission, CommissionPerTrade";
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(comissionFirst),
        //        "not contain line - " + comissionFirst);
        //    Assert.True(result.Contains(comissionsSecond),
        //        "not contain line - " + comissionsSecond);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //private void CheckTradingSetting(string result)
        //{
        //    string instrument = "Instrument: EUR/USD, Status: Market Open";
        //    string conditionDist = "Cond.Dist: ST=0; LT=0";
        //    string conditionDistEntry = "Cond.Dist entry stop=0; entry limit=0";
        //    string doneSampleMessange = "Done!";
        //    string levelMargin = "Single level margin: MMR=";
        //    string trailingStep = "Trailing step:";

        //    Assert.True(result.Contains(levelMargin),
        //        "not contain line - " + levelMargin);
        //    Assert.True(result.Contains(trailingStep),
        //        "not contain line - " + trailingStep);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    Assert.True(result.Contains(instrument),
        //        "not contain line - " + instrument);
        //    Assert.True(result.Contains(conditionDist),
        //        "not contain line - " + conditionDist);
        //    Assert.True(result.Contains(conditionDistEntry),
        //        "not contain line - " + conditionDistEntry);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_TradingSetting_Account_Y()
        //{
        //    CMD(PATH_TRADING_SETTING, CLEAN_BAT);
        //    CMD(PATH_TRADING_SETTING, BUILD_BAT);
        //    string result = CMD(PATH_TRADING_SETTING,
        //        RUN_PARAMETR_Y_ACCOUNT);
        //    CheckTradingSetting(result);
        //    CMD(PATH_TRADING_SETTING, CLEAN_BAT);
        //}

        //[Fact]
        //public void Cpp_NonTable_TwoConnection_Account_Y_and_N()
        //{
        //    CMD(PATH_TWO_CONNECTION, CLEAN_BAT);
        //    CMD(PATH_TWO_CONNECTION, BUILD_BAT);
        //    string result = CMD(PATH_TWO_CONNECTION,
        //        RUN_PARAMETR_FOR_SAMPLE_TWOCONNECTION);

        //    string account2 = "Account: 205736";
        //    string account1 = "Account: 97815";
        //    string timeForce = "TimeInForce='IOC'";
        //    string orderAdded = "The order has been added.";
        //    string typeOrder = "Type='OM', BuySell='B'";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(typeOrder),
        //        "not contain line - " + typeOrder);
        //    Assert.True(result.Contains(account2),
        //        "not contain line - " + account2);
        //    Assert.True(result.Contains(account1),
        //        "not contain line - " + account1);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);

        //    string doneSampleMessange = "Done!";
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //private void CheckGetOffers(string result)
        //{
        //    string nameSample = "Running GetOffers with arguments";
        //    string currancyPair = "EUR/USD";
        //    string bid = "Bid=";
        //    string doneSampleMessange = "Done!";
        //    string ask = "Ask=";

        //    Assert.True(result.Contains(nameSample),
        //        "not contain line - " + nameSample);
        //    Assert.True(result.Contains(currancyPair),
        //        "not contain line - " + currancyPair);
        //    Assert.True(result.Contains(bid),
        //        "not contain line - " + bid);
        //    Assert.True(result.Contains(ask),
        //        "not contain line - " + ask);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_GetOffers_Account_Y()
        //{
        //    CMD(PATH_GET_OFFERS, CLEAN_BAT);
        //    CMD(PATH_GET_OFFERS, BUILD_BAT);
        //    string result = CMD(PATH_GET_OFFERS,
        //        RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
        //    CheckGetOffers(result);
        //    CMD(PATH_GET_OFFERS, CLEAN_BAT);
        //}

        //[Fact]
        //public void Cpp_NonTable_SR_CloseAllPositionsByInstrument_Account_Y()
        //{
        //    CMD(PATH_CLOSE_ALL_POSTION_BY_INSTRUMENT, CLEAN_BAT);
        //    CMD(PATH_CLOSE_ALL_POSTION_BY_INSTRUMENT, BUILD_BAT);
        //    CMD(PATH_OPEN_POSITION, BUILD_BAT);
        //    CMD(PATH_OPEN_POSITION, RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT);
        //    string result = CMD(PATH_CLOSE_ALL_POSTION_BY_INSTRUMENT,
        //        RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT);
        //    CheckCloseAllPositionAllInstrument(result, AMOUNT_Y);
        //    CMD(PATH_CLOSE_ALL_POSTION_BY_INSTRUMENT, CLEAN_BAT);
        //}

        //private void CheckCloseAllPositionAllInstrument(string result, int amount)
        //{
        //    string orderAdded = "The order has been added. OrderID=";
        //    string timeForce = "TimeInForce='IOC'";
        //    string orderDelete = "The order has been deleted. OrderID=";
        //    string closeTrade = "For the order: OrderID=";
        //    string amountAcc = "Amount: " + amount;
        //    string doneSampleMessange = "Done!";

        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);
        //    Assert.True(result.Contains(orderDelete),
        //        "not contain line - " + orderDelete);
        //    Assert.True(result.Contains(closeTrade),
        //        "not contain line - " + closeTrade);
        //    Assert.True(result.Contains(amountAcc),
        //        "not contain line - " + amountAcc);
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //}

        //[Fact]
        //public void Cpp_NonTable_SearchInTable_Account_Y()
        //{
        //    CMD(PATH_CREATE_ENTRY, BUILD_BAT);
        //    string resultForID = CMD(PATH_CREATE_ENTRY,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);

        //    string orderID = FindOrderID(resultForID, "OrderID='");
        //    CMD(PATH_SEARCH_IN_TABLE, CLEAN_BAT);
        //    CMD(PATH_SEARCH_IN_TABLE, BUILD_BAT);
        //    string runLine = RUN_PARAMETR_Y_ACCOUNT + " /orderid " + orderID;
        //    string result = CMD(PATH_SEARCH_IN_TABLE, runLine);

        //    string checkLine = "OrderID='" + orderID +
        //        "', AccountID='97815', Type='LE', Status='W', OfferID='1', Amount='10000', BuySell='B', Rate='0.9', TimeInForce='GTC'";
        //    Assert.True(result.Contains(checkLine),
        //        "not contain line - " + checkLine);
        //    CheckError(result);
        //    CMD(PATH_SEARCH_IN_TABLE, CLEAN_BAT);
        //}

        //[Fact]
        //public void Cpp_NonTable_RemoveFromGroup_Account_Y()
        //{
        //    CMD(PATH_CREATE_OCO, BUILD_BAT);
        //    string resultForID = CMD(PATH_CREATE_OCO,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);

        //    string orderID = FindOrderID(resultForID, "OrderID='");
        //    CMD(PATH_REMOVE_FROM_GROUP, CLEAN_BAT);
        //    CMD(PATH_REMOVE_FROM_GROUP, BUILD_BAT);
        //    string runLine = RUN_PARAMETR_Y_ACCOUNT + " /orderid " + orderID;
        //    string result = CMD(PATH_REMOVE_FROM_GROUP, runLine);

        //    string checkLine = "The order has been updated. OrderID='" +
        //        orderID + "', ContingentOrderID='', ContingencyType='0'";
        //    Assert.True(result.Contains(checkLine),
        //        "not contain line - " + checkLine);
        //    CheckError(result);
        //    CMD(PATH_REMOVE_FROM_GROUP, CLEAN_BAT);
        //}

        //[Fact]
        //public void Cpp_NonTable_JoinNewGroup_Account_Y()
        //{
        //    CMD(PATH_CREATE_ENTRY, BUILD_BAT);
        //    string resultForIDFirst = CMD(PATH_CREATE_ENTRY,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);
        //    string orderIDFirst = FindOrderID(resultForIDFirst, "OrderID='");

        //    string resultForIDSecond = CMD(PATH_CREATE_ENTRY,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);
        //    string orderIDSecond = FindOrderID(resultForIDSecond, "OrderID='");

        //    CMD(PATH_JOIN_NEW_GROUP, CLEAN_BAT);
        //    CMD(PATH_JOIN_NEW_GROUP, BUILD_BAT);
        //    string runLine = RUN_PARAMETR_Y_ACCOUNT + " /primaryid " +
        //        orderIDFirst + " /secondaryid " + orderIDSecond;
        //    string result = CMD(PATH_JOIN_NEW_GROUP, runLine);

        //    string checkLineFirst = "The order has been updated. OrderID='" +
        //        orderIDFirst + "', ContingentOrderID='";
        //    Assert.True(result.Contains(checkLineFirst),
        //        "not contain line - " + checkLineFirst);

        //    string checkLineSecond = "The order has been updated. OrderID='" +
        //        orderIDSecond + "', ContingentOrderID='";
        //    Assert.True(result.Contains(checkLineSecond),
        //        "not contain line - " + checkLineSecond);

        //    CheckError(result);
        //    CMD(PATH_JOIN_NEW_GROUP, CLEAN_BAT);
        //}

        //[Fact]
        //public void Cpp_NonTable_JoinExistingGroup_Account_Y()
        //{
        //    CMD(PATH_CREATE_OCO, BUILD_BAT);
        //    string resultForContingentGroupID = CMD(PATH_CREATE_OCO,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);
        //    int contingentGroupID = int.Parse(FindOrderID(resultForContingentGroupID, "OrderID='")) + 1;

        //    CMD(PATH_CREATE_ENTRY, BUILD_BAT);
        //    string resultForID = CMD(PATH_CREATE_ENTRY,
        //        RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT);
        //    string orderID = FindOrderID(resultForID, "OrderID='");


        //    CMD(PATH_JOIN_EXISTING_GROUP, CLEAN_BAT);
        //    CMD(PATH_JOIN_EXISTING_GROUP, BUILD_BAT);
        //    string runLine = RUN_PARAMETR_Y_ACCOUNT + " /contingencyid " +
        //         contingentGroupID + "  /orderid " + orderID;
        //    string result = CMD(PATH_JOIN_EXISTING_GROUP, runLine);

        //    string checkLine = "The order has been updated. OrderID='" +
        //        orderID + "', ContingentOrderID='" + contingentGroupID +
        //        "', ContingencyType='1'";
        //    Assert.True(result.Contains(checkLine),
        //        "not contain line - " + checkLine);
        //}

        //[Fact]
        //public void Cpp_NonTable_OpenPositionNetting()
        //{
        //    CMD(PATH_OPEN_POSITION_NETTING, CLEAN_BAT);
        //    CMD(PATH_OPEN_POSITION_NETTING, BUILD_BAT);
        //    string result = CMD(PATH_OPEN_POSITION_NETTING,
        //        RUN_PARAMETR_NETTING_OPEN_POSITION);

        //    string timeForce = "TimeInForce='IOC'";
        //    Assert.True(result.Contains(timeForce),
        //        "not contain line - " + timeForce);

        //    string orderAdded = "The order has been added. OrderID='";
        //    Assert.True(result.Contains(orderAdded),
        //        "not contain line - " + orderAdded);

        //    string doneSampleMessange = "Done!";
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);

        //    CheckError(result);
        //    CMD(PATH_OPEN_POSITION_NETTING, CLEAN_BAT);
        //}

        ////TODO
        //[Fact]
        //public void Cpp_NonTable_CalculateTradingCommissions()
        //{
        //    CMD(PATH_CALCULATE_TRADING_COMMISSION, CLEAN_BAT);
        //    CMD(PATH_CALCULATE_TRADING_COMMISSION, BUILD_BAT);
        //    string result = CMD(PATH_CALCULATE_TRADING_COMMISSION,
        //        RUN_PARAMETR_FOR_SAMPLE_COMISSIONS);
        //    string comissionOpen = "Commission for open the position is";
        //    Assert.True(result.Contains(comissionOpen),
        //        "not contain line - " + comissionOpen);
        //    string commissionClose = "Commission for close the position is";
        //    Assert.True(result.Contains(commissionClose),
        //        "not contain line - " + commissionClose);
        //    string totalCommission = "Total commission for open and close the position is";
        //    Assert.True(result.Contains(totalCommission),
        //        "not contain line - " + totalCommission);
        //    string doneSampleMessange = "Done!";
        //    Assert.True(result.Contains(doneSampleMessange),
        //        "not contain line - " + doneSampleMessange);
        //    CheckError(result);
        //    CMD(PATH_CALCULATE_TRADING_COMMISSION, CLEAN_BAT);
        //}

        //[Fact]
        //public void Cpp_NonTable_GetHistPrice_Account_Y()
        //{
        //    CMD(PATH_GET_HIST_PRICE, CLEAN_BAT);
        //    CMD(PATH_GET_HIST_PRICE, BUILD_BAT);
        //    string result = CMD(PATH_GET_HIST_PRICE,
        //        RUN_PARAMETR_FOR_GET_HIST_PRICES);
        //    string complete = "is completed:";
        //    Assert.True(result.Contains(complete),
        //        "not contain line - " + complete);
        //    string eqalInfo = "DateTime=11.10.2017 0:00:00, BidOpen=1,18135, BidHigh=1,18277, " +
        //        "BidLow=1,18125, BidClose=1,18195, AskOpen=1,18137, AskHigh=1,18279, AskLow=1,18127, AskClose=1,18197, Volume=5516";
        //    Assert.True(result.Contains(eqalInfo),
        //        "not contain line - " + eqalInfo);
        //    CheckError(result);
        //    CMD(PATH_GET_HIST_PRICE, CLEAN_BAT);
        //}
    }
}
