using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workstation.ServiceModel.Ua;

namespace ConsoleApp2
{
    [Subscription(endpointUrl: "opc.tcp://localhost:4840", publishingInterval: 500, keepAliveCount: 20)]
    public class MainViewModel : SubscriptionBase
    {

        #region Inventory   
        /// <summary>
        /// Gets the value of ProgramInventoryBarley.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Inventory.Barley")]
        public Single ProgramInventoryBarley
        {
            get { return this.programInventoryBarley; }
            private set { this.SetProperty(ref this.programInventoryBarley, value); }
        }

        private Single programInventoryBarley;

        /// <summary>
        /// Gets the value of ProgramInventoryHops.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Inventory.Hops")]
        public Single ProgramInventoryHops
        {
            get { return this.programInventoryHops; }
            private set { this.SetProperty(ref this.programInventoryHops, value); }
        }

        private Single programInventoryHops;

        /// <summary>
        /// Gets the value of ProgramInventoryMalt.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Inventory.Malt")]
        public Single ProgramInventoryMalt
        {
            get { return this.programInventoryMalt; }
            private set { this.SetProperty(ref this.programInventoryMalt, value); }
        }

        private Single programInventoryMalt;

        /// <summary>
        /// Gets the value of ProgramInventoryYeast.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Inventory.Yeast")]
        public Single ProgramInventoryYeast
        {
            get { return this.programInventoryYeast; }
            private set { this.SetProperty(ref this.programInventoryYeast, value); }
        }

        private Single programInventoryYeast;

        /// <summary>
        /// Gets the value of ProgramInventoryWheat.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Inventory.Wheat")]
        public Single ProgramInventoryWheat
        {
            get { return this.programInventoryWheat; }
            private set { this.SetProperty(ref this.programInventoryWheat, value); }
        }

        private Single programInventoryWheat;

        #endregion

        #region Product
        /// <summary>
        /// Gets the value of Programproductproduce_amount.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:product.produce_amount")]
        public UInt16 Programproductproduce_amount
        {
            get { return this.programproductproduce_amount; }
            private set { this.SetProperty(ref this.programproductproduce_amount, value); }
        }

        private UInt16 programproductproduce_amount;

        /// <summary>
        /// Gets the value of Programproductproduced.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:product.produced")]
        public UInt16 Programproductproduced
        {
            get { return this.programproductproduced; }
            private set { this.SetProperty(ref this.programproductproduced, value); }
        }

        private UInt16 programproductproduced;


        /// <summary>
        /// Gets the value of Programproductgood.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:product.good")]
        public UInt16 Programproductgood
        {
            get { return this.programproductgood; }
            private set { this.SetProperty(ref this.programproductgood, value); }
        }

        private UInt16 programproductgood;

        /// <summary>
        /// Gets the value of Programproductbad.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:product.bad")]
        public UInt16 Programproductbad
        {
            get { return this.programproductbad; }
            private set { this.SetProperty(ref this.programproductbad, value); }
        }

        private UInt16 programproductbad;



        #endregion

        #region Commands
        /// <summary>
        /// Gets or sets the value of ProgramCubeCommandMachSpeed.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Command.MachSpeed")]
        public Single ProgramCubeCommandMachSpeed
        {
            get { return this.programCubeCommandMachSpeed; }
            set { this.SetProperty(ref this.programCubeCommandMachSpeed, value); }
        }

        private Single programCubeCommandMachSpeed;

        /// <summary>
        /// Gets or sets the value of ProgramCubeCommandCntrlCmd.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Command.CntrlCmd")]
        public Int32 ProgramCubeCommandCntrlCmd
        {
            get { return this.programCubeCommandCntrlCmd; }
            set { this.SetProperty(ref this.programCubeCommandCntrlCmd, value); }
        }

        private Int32 programCubeCommandCntrlCmd;

        /// <summary>
        /// Gets or sets the value of ProgramCubeCommandCmdChangeRequest.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Command.CmdChangeRequest")]
        public Boolean ProgramCubeCommandCmdChangeRequest
        {
            get { return this.programCubeCommandCmdChangeRequest; }
            set { this.SetProperty(ref this.programCubeCommandCmdChangeRequest, value); }
        }

        private Boolean programCubeCommandCmdChangeRequest;

        /// <summary>
        /// Gets or sets the value of ProgramCubeCommandParameter.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Command.Parameter")]
        public Object[] ProgramCubeCommandParameter
        {
            get { return this.programCubeCommandParameter; }
            set { this.SetProperty(ref this.programCubeCommandParameter, value); }
        }

        private Object[] programCubeCommandParameter;





        #endregion

        #region Status
        /// <summary>
        /// Gets the value of ProgramCubeStatusStateCurrent.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Status.StateCurrent")]
        public Int32 ProgramCubeStatusStateCurrent
        {
            get { return this.programCubeStatusStateCurrent; }
            private set { this.SetProperty(ref this.programCubeStatusStateCurrent, value); }
        }

        private Int32 programCubeStatusStateCurrent;

        /// <summary>
        /// Gets the value of ProgramCubeStatusMachSpeed.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Status.MachSpeed")]
        public Single ProgramCubeStatusMachSpeed
        {
            get { return this.programCubeStatusMachSpeed; }
            private set { this.SetProperty(ref this.programCubeStatusMachSpeed, value); }
        }

        private Single programCubeStatusMachSpeed;

        /// <summary>
        /// Gets the value of ProgramCubeStatusCurMachSpeed.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Status.CurMachSpeed")]
        public Single ProgramCubeStatusCurMachSpeed
        {
            get { return this.programCubeStatusCurMachSpeed; }
            private set { this.SetProperty(ref this.programCubeStatusCurMachSpeed, value); }
        }

        private Single programCubeStatusCurMachSpeed;

        /// <summary>
        /// Gets the value of ProgramCubeStatusParameter.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Status.Parameter")]
        public Object[] ProgramCubeStatusParameter
        {
            get { return this.programCubeStatusParameter; }
            private set { this.SetProperty(ref this.programCubeStatusParameter, value); }
        }

        private Object[] programCubeStatusParameter;


        #endregion

        #region Admin

        /// <summary>
        /// Gets the value of ProgramCubeAdminProdDefectiveCount.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Admin.ProdDefectiveCount")]
        public Int32 ProgramCubeAdminProdDefectiveCount
        {
            get { return this.programCubeAdminProdDefectiveCount; }
            private set { this.SetProperty(ref this.programCubeAdminProdDefectiveCount, value); }
        }

        private Int32 programCubeAdminProdDefectiveCount;


        /// <summary>
        /// Gets the value of ProgramCubeAdminProdProcessedCount.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Admin.ProdProcessedCount")]
        public Int32 ProgramCubeAdminProdProcessedCount
        {
            get { return this.programCubeAdminProdProcessedCount; }
            private set { this.SetProperty(ref this.programCubeAdminProdProcessedCount, value); }
        }

        private Int32 programCubeAdminProdProcessedCount;

        /// <summary>
        /// Gets the value of ProgramCubeAdminStopReason.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Admin.StopReason")]
        public Object ProgramCubeAdminStopReason
        {
            get { return this.programCubeAdminStopReason; }
            private set { this.SetProperty(ref this.programCubeAdminStopReason, value); }
        }

        private Object programCubeAdminStopReason;


        //Batch ID
        /// <summary>
        /// Gets the value of ProgramCubeAdminParameterParameter_0_Value.
        /// </summary>
        [MonitoredItem(nodeId: "ns=6;s=::Program:Cube.Admin.Parameter[0].Value")]
        public Single ProgramCubeAdminParameterParameter_0_Value
        {
            get { return this.programCubeAdminParameterParameter_0_Value; }
            private set { this.SetProperty(ref this.programCubeAdminParameterParameter_0_Value, value); }
        }

        private Single programCubeAdminParameterParameter_0_Value;


        #endregion

    }
}
