param serverName string
param serverLocation string
param elasticPoolName string
param skuName string
param tier string
param poolLimit int
param dataMaxSizeInBytes int
param perDatabasePerformanceMin int
param perDatabasePerformanceMax int
param zoneRedundant bool = false
param licenseType string = 'LicenseIncluded'

resource serverName_elasticPool 'Microsoft.Sql/servers/elasticpools@2021-08-01-preview' = {
    name: '${serverName}/${elasticPoolName}'
    location: serverLocation
    sku: {
        name: skuName
        tier: tier
        capacity: poolLimit
    }
    properties: {
        maxSizeBytes: dataMaxSizeInBytes
        perDatabaseSettings: {
            minCapacity: perDatabasePerformanceMin
            maxCapacity: perDatabasePerformanceMax
        }
        zoneRedundant: zoneRedundant
        licenseType: licenseType
    }
}