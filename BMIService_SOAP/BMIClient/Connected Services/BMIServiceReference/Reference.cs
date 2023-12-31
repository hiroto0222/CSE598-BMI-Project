﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BMIClient.BMIServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Health", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Health : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double bmiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string riskField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BMIClient.BMIServiceReference.ArrayOfString moreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double bmi {
            get {
                return this.bmiField;
            }
            set {
                if ((this.bmiField.Equals(value) != true)) {
                    this.bmiField = value;
                    this.RaisePropertyChanged("bmi");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string risk {
            get {
                return this.riskField;
            }
            set {
                if ((object.ReferenceEquals(this.riskField, value) != true)) {
                    this.riskField = value;
                    this.RaisePropertyChanged("risk");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public BMIClient.BMIServiceReference.ArrayOfString more {
            get {
                return this.moreField;
            }
            set {
                if ((object.ReferenceEquals(this.moreField, value) != true)) {
                    this.moreField = value;
                    this.RaisePropertyChanged("more");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BMIServiceReference.BMIServiceSoap")]
    public interface BMIServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MyBMI", ReplyAction="*")]
        double MyBMI(int height, int weight);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MyBMI", ReplyAction="*")]
        System.Threading.Tasks.Task<double> MyBMIAsync(int height, int weight);
        
        // CODEGEN: Generating message contract since element name MyHealthResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MyHealth", ReplyAction="*")]
        BMIClient.BMIServiceReference.MyHealthResponse MyHealth(BMIClient.BMIServiceReference.MyHealthRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MyHealth", ReplyAction="*")]
        System.Threading.Tasks.Task<BMIClient.BMIServiceReference.MyHealthResponse> MyHealthAsync(BMIClient.BMIServiceReference.MyHealthRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MyHealthRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MyHealth", Namespace="http://tempuri.org/", Order=0)]
        public BMIClient.BMIServiceReference.MyHealthRequestBody Body;
        
        public MyHealthRequest() {
        }
        
        public MyHealthRequest(BMIClient.BMIServiceReference.MyHealthRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MyHealthRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int height;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int weight;
        
        public MyHealthRequestBody() {
        }
        
        public MyHealthRequestBody(int height, int weight) {
            this.height = height;
            this.weight = weight;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MyHealthResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MyHealthResponse", Namespace="http://tempuri.org/", Order=0)]
        public BMIClient.BMIServiceReference.MyHealthResponseBody Body;
        
        public MyHealthResponse() {
        }
        
        public MyHealthResponse(BMIClient.BMIServiceReference.MyHealthResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MyHealthResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public BMIClient.BMIServiceReference.Health MyHealthResult;
        
        public MyHealthResponseBody() {
        }
        
        public MyHealthResponseBody(BMIClient.BMIServiceReference.Health MyHealthResult) {
            this.MyHealthResult = MyHealthResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BMIServiceSoapChannel : BMIClient.BMIServiceReference.BMIServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BMIServiceSoapClient : System.ServiceModel.ClientBase<BMIClient.BMIServiceReference.BMIServiceSoap>, BMIClient.BMIServiceReference.BMIServiceSoap {
        
        public BMIServiceSoapClient() {
        }
        
        public BMIServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BMIServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BMIServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BMIServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double MyBMI(int height, int weight) {
            return base.Channel.MyBMI(height, weight);
        }
        
        public System.Threading.Tasks.Task<double> MyBMIAsync(int height, int weight) {
            return base.Channel.MyBMIAsync(height, weight);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        BMIClient.BMIServiceReference.MyHealthResponse BMIClient.BMIServiceReference.BMIServiceSoap.MyHealth(BMIClient.BMIServiceReference.MyHealthRequest request) {
            return base.Channel.MyHealth(request);
        }
        
        public BMIClient.BMIServiceReference.Health MyHealth(int height, int weight) {
            BMIClient.BMIServiceReference.MyHealthRequest inValue = new BMIClient.BMIServiceReference.MyHealthRequest();
            inValue.Body = new BMIClient.BMIServiceReference.MyHealthRequestBody();
            inValue.Body.height = height;
            inValue.Body.weight = weight;
            BMIClient.BMIServiceReference.MyHealthResponse retVal = ((BMIClient.BMIServiceReference.BMIServiceSoap)(this)).MyHealth(inValue);
            return retVal.Body.MyHealthResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<BMIClient.BMIServiceReference.MyHealthResponse> BMIClient.BMIServiceReference.BMIServiceSoap.MyHealthAsync(BMIClient.BMIServiceReference.MyHealthRequest request) {
            return base.Channel.MyHealthAsync(request);
        }
        
        public System.Threading.Tasks.Task<BMIClient.BMIServiceReference.MyHealthResponse> MyHealthAsync(int height, int weight) {
            BMIClient.BMIServiceReference.MyHealthRequest inValue = new BMIClient.BMIServiceReference.MyHealthRequest();
            inValue.Body = new BMIClient.BMIServiceReference.MyHealthRequestBody();
            inValue.Body.height = height;
            inValue.Body.weight = weight;
            return ((BMIClient.BMIServiceReference.BMIServiceSoap)(this)).MyHealthAsync(inValue);
        }
    }
}
