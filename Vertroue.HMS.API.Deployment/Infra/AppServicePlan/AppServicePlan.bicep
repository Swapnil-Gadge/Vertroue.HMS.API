param appServicePlanName string
param location string = resourceGroup().location
param sku string = 'P1'
param capacity int = 1

resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: appServicePlanName
  location: location 
  sku: {
    name: sku
    capacity: capacity
  }
  kind: 'linux'
}