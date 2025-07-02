param storageAccountName string
param storageAccountSkuName string = 'Standard_LRS'
param location string = resourceGroup().location

resource stg 'Microsoft.Storage/storageAccounts@2021-02-01' = {
    name: storageAccountName
    location: location
    sku: {
        name: storageAccountSkuName
    }
    kind: 'StorageV2'
    properties: {
        minimumTlsVersion: 'TLS1_0'
        supportsHttpsTrafficOnly: true
        accessTier: 'Hot'
    }
}

output storageAccountName string = storageAccountName