﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Hpc.Excel.ExcelService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExcelService.IExcelService")]
    public interface IExcelService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExcelService/Calculate", ReplyAction="http://tempuri.org/IExcelService/CalculateResponse")]
        Microsoft.Hpc.Excel.ExcelService.CalculateResponse Calculate(Microsoft.Hpc.Excel.ExcelService.CalculateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IExcelService/Calculate", ReplyAction="http://tempuri.org/IExcelService/CalculateResponse")]
        System.IAsyncResult BeginCalculate(Microsoft.Hpc.Excel.ExcelService.CalculateRequest request, System.AsyncCallback callback, object asyncState);
        
        Microsoft.Hpc.Excel.ExcelService.CalculateResponse EndCalculate(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Calculate", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CalculateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string macroName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public byte[] inputs;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.Nullable<System.DateTime> lastSaveDate;
        
        public CalculateRequest() {
        }
        
        public CalculateRequest(string macroName, byte[] inputs, System.Nullable<System.DateTime> lastSaveDate) {
            this.macroName = macroName;
            this.inputs = inputs;
            this.lastSaveDate = lastSaveDate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CalculateResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CalculateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public byte[] CalculateResult;
        
        public CalculateResponse() {
        }
        
        public CalculateResponse(byte[] CalculateResult) {
            this.CalculateResult = CalculateResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExcelServiceChannel : Microsoft.Hpc.Excel.ExcelService.IExcelService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CalculateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Microsoft.Hpc.Excel.ExcelService.CalculateResponse Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Microsoft.Hpc.Excel.ExcelService.CalculateResponse)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExcelServiceClient : System.ServiceModel.ClientBase<Microsoft.Hpc.Excel.ExcelService.IExcelService>, Microsoft.Hpc.Excel.ExcelService.IExcelService {
        
        private BeginOperationDelegate onBeginCalculateDelegate;
        
        private EndOperationDelegate onEndCalculateDelegate;
        
        private System.Threading.SendOrPostCallback onCalculateCompletedDelegate;
        
        public ExcelServiceClient() {
        }
        
        public ExcelServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExcelServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExcelServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExcelServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<CalculateCompletedEventArgs> CalculateCompleted;
        
        public Microsoft.Hpc.Excel.ExcelService.CalculateResponse Calculate(Microsoft.Hpc.Excel.ExcelService.CalculateRequest request) {
            return base.Channel.Calculate(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCalculate(Microsoft.Hpc.Excel.ExcelService.CalculateRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCalculate(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Microsoft.Hpc.Excel.ExcelService.CalculateResponse EndCalculate(System.IAsyncResult result) {
            return base.Channel.EndCalculate(result);
        }
        
        private System.IAsyncResult OnBeginCalculate(object[] inValues, System.AsyncCallback callback, object asyncState) {
            Microsoft.Hpc.Excel.ExcelService.CalculateRequest request = ((Microsoft.Hpc.Excel.ExcelService.CalculateRequest)(inValues[0]));
            return this.BeginCalculate(request, callback, asyncState);
        }
        
        private object[] OnEndCalculate(System.IAsyncResult result) {
            Microsoft.Hpc.Excel.ExcelService.CalculateResponse retVal = this.EndCalculate(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCalculateCompleted(object state) {
            if ((this.CalculateCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CalculateCompleted(this, new CalculateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CalculateAsync(Microsoft.Hpc.Excel.ExcelService.CalculateRequest request) {
            this.CalculateAsync(request, null);
        }
        
        public void CalculateAsync(Microsoft.Hpc.Excel.ExcelService.CalculateRequest request, object userState) {
            if ((this.onBeginCalculateDelegate == null)) {
                this.onBeginCalculateDelegate = new BeginOperationDelegate(this.OnBeginCalculate);
            }
            if ((this.onEndCalculateDelegate == null)) {
                this.onEndCalculateDelegate = new EndOperationDelegate(this.OnEndCalculate);
            }
            if ((this.onCalculateCompletedDelegate == null)) {
                this.onCalculateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCalculateCompleted);
            }
            base.InvokeAsync(this.onBeginCalculateDelegate, new object[] {
                        request}, this.onEndCalculateDelegate, this.onCalculateCompletedDelegate, userState);
        }
    }
}
