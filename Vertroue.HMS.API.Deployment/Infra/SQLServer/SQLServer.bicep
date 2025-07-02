param sqlServerName string
param sqlAdminUsername string
@secure()
param sqlAdminPassword string
param adAdminGroupName string
param location string = resourceGroup().location

var SqlServerFirewall = [
    {
        name: 'Prisma_India_North_1'
        startIpAddress: '66.159.202.2'
        endIpAddress: '66.159.202.2'
    }
    {
        name: 'Prisma_India_North_10'
        startIpAddress: '208.127.31.205'
        endIpAddress: '208.127.31.205'
    }
    {
        name: 'Prisma_India_North_2'
        startIpAddress: '66.159.202.20'
        endIpAddress: '66.159.202.20'
    }
    {
        name: 'Prisma_India_North_3'
        startIpAddress: '66.159.202.25'
        endIpAddress: '66.159.202.25'
    }
    {
        name: 'Prisma_India_North_4'
        startIpAddress: '66.159.202.250'
        endIpAddress: '66.159.202.250'
    }
    {
        name: 'Prisma_India_North_5'
        startIpAddress: '134.238.18.6'
        endIpAddress: '134.238.18.6'
    }
    {
        name: 'Prisma_India_North_6'
        startIpAddress: '134.238.18.55'
        endIpAddress: '134.238.18.55'
    }
    {
        name: 'Prisma_India_North_7'
        startIpAddress: '134.238.18.185'
        endIpAddress: '134.238.18.185'
    }
    {
        name: 'Prisma_India_North_8'
        startIpAddress: '134.238.18.186'
        endIpAddress: '134.238.18.186'
    }
    {
        name: 'Prisma_India_North_9'
        startIpAddress: '208.127.31.29'
        endIpAddress: '208.127.31.29'
    }
    {
        name: 'Prisma_India_South_1'
        startIpAddress: '134.238.8.171'
        endIpAddress: '134.238.8.171'
    }
    {
        name: 'Prisma_India_South_10'
        startIpAddress: '134.238.253.98'
        endIpAddress: '134.238.253.98'
    }
    {
        name: 'Prisma_India_South_2'
        startIpAddress: '134.238.8.172'
        endIpAddress: '134.238.8.172'
    }
    {
        name: 'Prisma_India_South_3'
        startIpAddress: '134.238.241.88'
        endIpAddress: '134.238.241.88'
    }
    {
        name: 'Prisma_India_South_4'
        startIpAddress: '134.238.241.136'
        endIpAddress: '134.238.241.136'
    }
    {
        name: 'Prisma_India_South_5'
        startIpAddress: '134.238.253.37'
        endIpAddress: '134.238.253.37'
    }
    {
        name: 'Prisma_India_South_6'
        startIpAddress: '134.238.253.38'
        endIpAddress: '134.238.253.38'
    }
    {
        name: 'Prisma_India_South_7'
        startIpAddress: '134.238.253.58'
        endIpAddress: '134.238.253.58'
    }
    {
        name: 'Prisma_India_South_8'
        startIpAddress: '134.238.253.59'
        endIpAddress: '134.238.253.59'
    }
    {
        name: 'Prisma_India_South_9'
        startIpAddress: '134.238.253.97'
        endIpAddress: '134.238.253.97'
    }
    {
        name: 'Prisma_India_West_1'
        startIpAddress: '134.238.14.14'
        endIpAddress: '134.238.14.14'
    }
    {
        name: 'Prisma_India_West_10'
        startIpAddress: '165.1.239.247'
        endIpAddress: '165.1.239.247'
    }
    {
        name: 'Prisma_India_West_11'
        startIpAddress: '208.127.30.137'
        endIpAddress: '208.127.30.137'
    }
    {
        name: 'Prisma_India_West_2'
        startIpAddress: '134.238.15.183'
        endIpAddress: '134.238.15.183'
    }
    {
        name: 'Prisma_India_West_3'
        startIpAddress: '134.238.15.184'
        endIpAddress: '134.238.15.184'
    }
    {
        name: 'Prisma_India_West_4'
        startIpAddress: '134.238.248.70'
        endIpAddress: '134.238.248.70'
    }
    {
        name: 'Prisma_India_West_5'
        startIpAddress: '134.238.248.71'
        endIpAddress: '134.238.248.71'
    }
    {
        name: 'Prisma_India_West_6'
        startIpAddress: '134.238.252.37'
        endIpAddress: '134.238.252.37'
    }
    {
        name: 'Prisma_India_West_7'
        startIpAddress: '134.238.252.38'
        endIpAddress: '134.238.252.38'
    }
    {
        name: 'Prisma_India_West_8'
        startIpAddress: '165.1.238.77'
        endIpAddress: '165.1.238.77'
    }
    {
        name: 'Prisma_India_West_9'
        startIpAddress: '165.1.239.219'
        endIpAddress: '165.1.239.219'
    }
    {
        name: 'Prisma_Ireland_1'
        startIpAddress: '137.83.212.80'
        endIpAddress: '137.83.212.80'
    }
    {
        name: 'Prisma_Ireland_2'
        startIpAddress: '208.127.203.143'
        endIpAddress: '208.127.203.143'
    }
    {
        name: 'Prisma_Ireland_3'
        startIpAddress: '208.127.203.144'
        endIpAddress: '208.127.203.144'
    }
    {
        name: 'Prisma_Ireland_4'
        startIpAddress: '208.127.203.155'
        endIpAddress: '208.127.203.155'
    }
    {
        name: 'Prisma_Ireland_5'
        startIpAddress: '208.127.203.156'
        endIpAddress: '208.127.203.156'
    }
    {
        name: 'Prisma_Poland_1'
        startIpAddress: '130.41.32.75'
        endIpAddress: '130.41.32.75'
    }
    {
        name: 'Prisma_Poland_2'
        startIpAddress: '130.41.32.76'
        endIpAddress: '130.41.32.76'
    }
    {
        name: 'Prisma_Poland_3'
        startIpAddress: '130.41.32.83'
        endIpAddress: '130.41.32.83'
    }
    {
        name: 'Prisma_Poland_4'
        startIpAddress: '130.41.32.84'
        endIpAddress: '130.41.32.84'
    }
    {
        name: 'Prisma_Poland_5'
        startIpAddress: '130.41.84.146'
        endIpAddress: '130.41.84.146'
    }
    {
        name: 'Prisma_Poland_6'
        startIpAddress: '130.41.84.147'
        endIpAddress: '130.41.84.147'
    }
    {
        name: 'Prisma_Poland_7'
        startIpAddress: '134.238.133.128'
        endIpAddress: '134.238.133.128'
    }
    {
        name: 'Prisma_Poland_8'
        startIpAddress: '134.238.134.108'
        endIpAddress: '134.238.134.108'
    }
    {
        name: 'Prisma_UK_1'
        startIpAddress: '34.98.178.220'
        endIpAddress: '34.98.178.220'
    }
    {
        name: 'Prisma_UK_10'
        startIpAddress: '134.238.53.157'
        endIpAddress: '134.238.53.157'
    }
    {
        name: 'Prisma_UK_11'
        startIpAddress: '208.127.46.120'
        endIpAddress: '208.127.46.120'
    }
    {
        name: 'Prisma_UK_12'
        startIpAddress: '208.127.46.121'
        endIpAddress: '208.127.46.121'
    }
    {
        name: 'Prisma_UK_13'
        startIpAddress: '208.127.46.122'
        endIpAddress: '208.127.46.122'
    }
    {
        name: 'Prisma_UK_14'
        startIpAddress: '208.127.46.123'
        endIpAddress: '208.127.46.123'
    }
    {
        name: 'Prisma_UK_15'
        startIpAddress: '208.127.46.124'
        endIpAddress: '208.127.46.124'
    }
    {
        name: 'Prisma_UK_16'
        startIpAddress: '208.127.46.125'
        endIpAddress: '208.127.46.125'
    }
    {
        name: 'Prisma_UK_17'
        startIpAddress: '208.127.53.27'
        endIpAddress: '208.127.53.27'
    }
    {
        name: 'Prisma_UK_2'
        startIpAddress: '34.98.178.232'
        endIpAddress: '34.98.178.232'
    }
    {
        name: 'Prisma_UK_3'
        startIpAddress: '134.238.52.25'
        endIpAddress: '134.238.52.25'
    }
    {
        name: 'Prisma_UK_4'
        startIpAddress: '134.238.52.32'
        endIpAddress: '134.238.52.32'
    }
    {
        name: 'Prisma_UK_5'
        startIpAddress: '134.238.52.47'
        endIpAddress: '134.238.52.47'
    }
    {
        name: 'Prisma_UK_6'
        startIpAddress: '134.238.52.249'
        endIpAddress: '134.238.52.249'
    }
    {
        name: 'Prisma_UK_7'
        startIpAddress: '134.238.52.250'
        endIpAddress: '134.238.52.250'
    }
    {
        name: 'Prisma_UK_8'
        startIpAddress: '134.238.53.145'
        endIpAddress: '134.238.53.145'
    }
    {
        name: 'Prisma_UK_9'
        startIpAddress: '134.238.53.146'
        endIpAddress: '134.238.53.146'
    }
    {
        name: 'Azure_Palo_NEU'
        startIpAddress: '20.54.58.248'
        endIpAddress: '20.54.58.251'
    }
    {
        name: 'Azure_Palo_WEU'
        startIpAddress: '40.114.182.48'
        endIpAddress: '40.114.182.51'
    }
    {
        name: 'Bluecoat_CORP_1'
        startIpAddress: '80.247.49.10'
        endIpAddress: '80.247.49.10'
    }
    {
        name: 'Bluecoat_CORP_2'
        startIpAddress: '80.247.55.10'
        endIpAddress: '80.247.55.10'
    }
    {
        name: 'Bluecoat_MG_1'
        startIpAddress: '80.247.60.10'
        endIpAddress: '80.247.60.10'
    }
    {
        name: 'Bluecoat_MG_2'
        startIpAddress: '80.247.61.10'
        endIpAddress: '80.247.61.10'
    }
    {
        name: 'Bluecoat_PruUK_1'
        startIpAddress: '80.247.53.97'
        endIpAddress: '80.247.53.97'
    }
    {
        name: 'Bluecoat_PruUK_2'
        startIpAddress: '80.247.52.199'
        endIpAddress: '80.247.52.199'
    }
    {
        name: 'CloudConnect_FW_NEU_1'
        startIpAddress: '80.247.57.32'
        endIpAddress: '80.247.57.47'
    }
    {
        name: 'CloudConnect_FW_NEU_2'
        startIpAddress: '80.247.57.48'
        endIpAddress: '80.247.57.63'
    }
    {
        name: 'CloudConnect_FW_NEU_3'
        startIpAddress: '80.247.57.64'
        endIpAddress: '80.247.57.79'
    }
    {
        name: 'CloudConnect_FW_WEU_1'
        startIpAddress: '80.247.57.160'
        endIpAddress: '80.247.57.175'
    }
    {
        name: 'CloudConnect_FW_WEU_2'
        startIpAddress: '80.247.57.176'
        endIpAddress: '80.247.57.191'
    }
    {
        name: 'CloudConnect_FW_WEU_3'
        startIpAddress: '80.247.57.192'
        endIpAddress: '80.247.57.207'
    }
    {
        name: 'AllowAllWindowsAzureIps'
        startIpAddress: '0.0.0.0'
        endIpAddress: '0.0.0.0'
    }
]

resource server 'Microsoft.Sql/servers@2021-11-01-preview' = {
    name: sqlServerName
    location: location
    identity: {
        type: 'SystemAssigned'
    }
    properties: {
        administratorLogin: sqlAdminUsername
        administratorLoginPassword: sqlAdminPassword
        administrators: {
            administratorType: 'ActiveDirectory'
            azureADOnlyAuthentication: false
            login: adAdminGroupName
            sid: reference(adAdminGroupName).objectId
            principalType: 'Group'
            tenantId: subscription().tenantId
        }
        minimalTlsVersion: '1.2'
        publicNetworkAccess: 'Enabled'
        restrictOutboundNetworkAccess: 'Disabled'
        version: '12.0'
    }
}

resource sqlFirewall 'Microsoft.Sql/servers/firewallRules@2022-05-01-preview' = [for firewall in SqlServerFirewall: {
    name: firewall.name
    parent: server
    properties: {
        startIpAddress: firewall.startIpAddress
        endIpAddress: firewall.endIpAddress
    }
}]

output name string = server.name