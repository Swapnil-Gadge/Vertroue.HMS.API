param keyVaultName string
param keyVaultSku string = 'Standard'
param location string = resourceGroup().location

resource KeyVault 'Microsoft.KeyVault/vaults@2018-02-14' = {
    name: keyVaultName
    location: location
    properties: {
        enabledForDeployment: false
        enabledForTemplateDeployment: true
        enabledForDiskEncryption: false
        tenantId: subscription().tenantId
        sku: {
            name: keyVaultSku
            family: 'A'
        }
    }
}

output keyVaultName string = keyVaultName