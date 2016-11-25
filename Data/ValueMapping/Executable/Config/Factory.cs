using Data.Entities.Executable.Config;

namespace Data.ValueMapping.Executable.Config
{
    public class Factory : IFactory
    {
        // Offset values
        private const int HeadquartersConstructionCostBaseOffset = 1118525;
        private const int HeadquartersOverheadBaseOffset = 2694108;
        private const int WindTunnelHirageCostBaseOffset = 1118026;
        private const int WindTunnelConstructionCostBaseOffset = 1118204;
        private const int SupercomputerConstructionCostBaseOffset = 1118252;
        private const int CamConstructionCostBaseOffset = 1118294;
        private const int CadConstructionCostBaseOffset = 1118336;
        private const int WorkshopConstructionCostBaseOffset = 1118378;
        private const int TestRigConstructionCostBaseOffset = 1118420;

        private const int Step4ValueOffset01 = 0;
        private const int Step4ValueOffset02 = 4;
        private const int Step4ValueOffset03 = 8;
        private const int Step4ValueOffset04 = 12;
        private const int Step4ValueOffset05 = 16;
        private const int Step7ValueOffset01 = 0;
        private const int Step7ValueOffset02 = 7;
        private const int Step7ValueOffset03 = 14;
        private const int Step7ValueOffset04 = 21;
        private const int Step7ValueOffset05 = 28;
        private const int WindTunnelConstructionCostValueOffset01 = 0;
        private const int WindTunnelConstructionCostValueOffset02 = 10;
        private const int WindTunnelConstructionCostValueOffset03 = 20;
        private const int WindTunnelConstructionCostValueOffset04 = 27;
        private const int WindTunnelConstructionCostValueOffset05 = 34;

        public int HeadquartersConstructionCost01 { get; set; }
        public int HeadquartersConstructionCost02 { get; set; }
        public int HeadquartersConstructionCost03 { get; set; }
        public int HeadquartersConstructionCost04 { get; set; }
        public int HeadquartersConstructionCost05 { get; set; }

        public int HeadquartersOverhead01 { get; set; }
        public int HeadquartersOverhead02 { get; set; }
        public int HeadquartersOverhead03 { get; set; }
        public int HeadquartersOverhead04 { get; set; }
        public int HeadquartersOverhead05 { get; set; }

        public int WindTunnelHirageCost01 { get; set; }
        public int WindTunnelHirageCost02 { get; set; }
        public int WindTunnelHirageCost03 { get; set; }
        public int WindTunnelHirageCost04 { get; set; }
        public int WindTunnelHirageCost05 { get; set; }

        public int WindTunnelConstructionCost01 { get; set; }
        public int WindTunnelConstructionCost02 { get; set; }
        public int WindTunnelConstructionCost03 { get; set; }
        public int WindTunnelConstructionCost04 { get; set; }
        public int WindTunnelConstructionCost05 { get; set; }

        public int SupercomputerConstructionCost01 { get; set; }
        public int SupercomputerConstructionCost02 { get; set; }
        public int SupercomputerConstructionCost03 { get; set; }
        public int SupercomputerConstructionCost04 { get; set; }
        public int SupercomputerConstructionCost05 { get; set; }

        public int CamConstructionCost01 { get; set; }
        public int CamConstructionCost02 { get; set; }
        public int CamConstructionCost03 { get; set; }
        public int CamConstructionCost04 { get; set; }
        public int CamConstructionCost05 { get; set; }

        public int CadConstructionCost01 { get; set; }
        public int CadConstructionCost02 { get; set; }
        public int CadConstructionCost03 { get; set; }
        public int CadConstructionCost04 { get; set; }
        public int CadConstructionCost05 { get; set; }

        public int WorkshopConstructionCost01 { get; set; }
        public int WorkshopConstructionCost02 { get; set; }
        public int WorkshopConstructionCost03 { get; set; }
        public int WorkshopConstructionCost04 { get; set; }
        public int WorkshopConstructionCost05 { get; set; }

        public int TestRigConstructionCost01 { get; set; }
        public int TestRigConstructionCost02 { get; set; }
        public int TestRigConstructionCost03 { get; set; }
        public int TestRigConstructionCost04 { get; set; }
        public int TestRigConstructionCost05 { get; set; }

        public Factory()
        {
            HeadquartersConstructionCost01 = HeadquartersConstructionCostBaseOffset + Step7ValueOffset01;
            HeadquartersConstructionCost02 = HeadquartersConstructionCostBaseOffset + Step7ValueOffset02;
            HeadquartersConstructionCost03 = HeadquartersConstructionCostBaseOffset + Step7ValueOffset03;
            HeadquartersConstructionCost04 = HeadquartersConstructionCostBaseOffset + Step7ValueOffset04;
            HeadquartersConstructionCost05 = HeadquartersConstructionCostBaseOffset + Step7ValueOffset05;

            HeadquartersOverhead01 = HeadquartersOverheadBaseOffset + Step4ValueOffset01;
            HeadquartersOverhead02 = HeadquartersOverheadBaseOffset + Step4ValueOffset02;
            HeadquartersOverhead03 = HeadquartersOverheadBaseOffset + Step4ValueOffset03;
            HeadquartersOverhead04 = HeadquartersOverheadBaseOffset + Step4ValueOffset04;
            HeadquartersOverhead05 = HeadquartersOverheadBaseOffset + Step4ValueOffset05;

            WindTunnelHirageCost01 = WindTunnelHirageCostBaseOffset + Step7ValueOffset01;
            WindTunnelHirageCost02 = WindTunnelHirageCostBaseOffset + Step7ValueOffset02;
            WindTunnelHirageCost03 = WindTunnelHirageCostBaseOffset + Step7ValueOffset03;
            WindTunnelHirageCost04 = WindTunnelHirageCostBaseOffset + Step7ValueOffset04;
            WindTunnelHirageCost05 = WindTunnelHirageCostBaseOffset + Step7ValueOffset05;

            WindTunnelConstructionCost01 = WindTunnelConstructionCostBaseOffset + WindTunnelConstructionCostValueOffset01;
            WindTunnelConstructionCost02 = WindTunnelConstructionCostBaseOffset + WindTunnelConstructionCostValueOffset02;
            WindTunnelConstructionCost03 = WindTunnelConstructionCostBaseOffset + WindTunnelConstructionCostValueOffset03;
            WindTunnelConstructionCost04 = WindTunnelConstructionCostBaseOffset + WindTunnelConstructionCostValueOffset04;
            WindTunnelConstructionCost05 = WindTunnelConstructionCostBaseOffset + WindTunnelConstructionCostValueOffset05;

            SupercomputerConstructionCost01 = SupercomputerConstructionCostBaseOffset + Step7ValueOffset01;
            SupercomputerConstructionCost02 = SupercomputerConstructionCostBaseOffset + Step7ValueOffset02;
            SupercomputerConstructionCost03 = SupercomputerConstructionCostBaseOffset + Step7ValueOffset03;
            SupercomputerConstructionCost04 = SupercomputerConstructionCostBaseOffset + Step7ValueOffset04;
            SupercomputerConstructionCost05 = SupercomputerConstructionCostBaseOffset + Step7ValueOffset05;

            CamConstructionCost01 = CamConstructionCostBaseOffset + Step7ValueOffset01;
            CamConstructionCost02 = CamConstructionCostBaseOffset + Step7ValueOffset02;
            CamConstructionCost03 = CamConstructionCostBaseOffset + Step7ValueOffset03;
            CamConstructionCost04 = CamConstructionCostBaseOffset + Step7ValueOffset04;
            CamConstructionCost05 = CamConstructionCostBaseOffset + Step7ValueOffset05;

            CadConstructionCost01 = CadConstructionCostBaseOffset + Step7ValueOffset01;
            CadConstructionCost02 = CadConstructionCostBaseOffset + Step7ValueOffset02;
            CadConstructionCost03 = CadConstructionCostBaseOffset + Step7ValueOffset03;
            CadConstructionCost04 = CadConstructionCostBaseOffset + Step7ValueOffset04;
            CadConstructionCost05 = CadConstructionCostBaseOffset + Step7ValueOffset05;

            WorkshopConstructionCost01 = WorkshopConstructionCostBaseOffset + Step7ValueOffset01;
            WorkshopConstructionCost02 = WorkshopConstructionCostBaseOffset + Step7ValueOffset02;
            WorkshopConstructionCost03 = WorkshopConstructionCostBaseOffset + Step7ValueOffset03;
            WorkshopConstructionCost04 = WorkshopConstructionCostBaseOffset + Step7ValueOffset04;
            WorkshopConstructionCost05 = WorkshopConstructionCostBaseOffset + Step7ValueOffset05;

            TestRigConstructionCost01 = TestRigConstructionCostBaseOffset + Step7ValueOffset01;
            TestRigConstructionCost02 = TestRigConstructionCostBaseOffset + Step7ValueOffset02;
            TestRigConstructionCost03 = TestRigConstructionCostBaseOffset + Step7ValueOffset03;
            TestRigConstructionCost04 = TestRigConstructionCostBaseOffset + Step7ValueOffset04;
            TestRigConstructionCost05 = TestRigConstructionCostBaseOffset + Step7ValueOffset05;
        }
    }
}
