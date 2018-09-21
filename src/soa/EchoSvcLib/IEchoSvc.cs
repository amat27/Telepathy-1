//-----------------------------------------------------------------------
// <copyright file="IEchoSvc.cs" company="Microsoft">
//     Copyright   Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     Service contract for the echo service.
// </summary>
//-----------------------------------------------------------------------
namespace Microsoft.Hpc.EchoSvcLib
{
    using System.ServiceModel;
    using Microsoft.Hpc.Scheduler.Session.GenericService;

    /// <summary>
    /// Service contract of the echo service.
    /// </summary>
    [ServiceContract]
    public interface IEchoSvc
    {
        /// <summary>
        /// Echo the input data.
        /// </summary>
        /// <param name="input">input data</param>
        /// <returns>the echo string</returns>
        [OperationContract]
        string Echo(string input);

        /// <summary>
        /// Echo the data retrieved by data client.
        /// </summary>
        /// <param name="dataClientId">data client id</param>
        /// <returns>the echo string</returns>
        [OperationContract]
        int EchoData(string dataClientId);

        /// <summary>
        /// Generate load on the machine.
        /// </summary>
        /// <param name="runMilliSeconds">the run time span</param>
        /// <param name="dummyData">the dummy data</param>
        /// <param name="fileData">the file path</param>
        /// <returns>statistic info of the load</returns>
        [OperationContract]
        StatisticInfo GenerateLoad(double runMilliSeconds, byte[] dummyData, string fileData);

        /// <summary>
        /// Echo generic request.
        /// </summary>
        /// <param name="input">service request</param>
        /// <returns>the echo response</returns>
        [OperationContract(Name = "GenericOperation", Action = "http://hpc.microsoft.com/GenericService/IGenericService/GenericOperation", ReplyAction = "http://hpc.microsoft.com/GenericService/IGenericService/GenericOperationResponse")]
        GenericServiceResponse EchoGeneric(GenericServiceRequest input);
    }
}
