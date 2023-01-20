namespace ROASApplication.Business
{
    public class ROAS
    {       
            public string channelName;
            public double costOfAdvertising;
            public int soldPieces;
            public double pricePerUnit;
            public double CalcROAS()
            {
                return ((soldPieces * pricePerUnit) / costOfAdvertising) * 100;

            }
    }
}