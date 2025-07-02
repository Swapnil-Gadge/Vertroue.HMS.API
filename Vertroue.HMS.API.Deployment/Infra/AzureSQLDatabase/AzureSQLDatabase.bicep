param sqlServerName string
param sqlDatabaseName string
param sqlElasticPoolName string
param skuName string
param skuTier string
param skuCapacity int
param maxSizeInBytes int

param location string = resourceGroup().location

resource sqlDB 'Microsoft.Sql/servers/databases@2022-05-01-preview' = {
    name: format('{0}/{1}', sqlServerName, sqlDatabaseName)
    location: location
    properties:{
        elasticPoolId: reference(sqlElasticPoolName).id
        maxSizeBytes: maxSizeInBytes
        zoneRedundant: false
    }
    sku: {
        name: skuName
        tier: skuTier
        capacity: skuCapacity
    }
}