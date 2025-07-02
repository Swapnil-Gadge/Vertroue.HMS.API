$resourceGroupName = "$(ResourceGroupName)"
$location = "$(ResourceGroupLocation)"
$tags = @{
    ProductName = "<ProductName>"
    ProductOwner = "<ProductOwner>"
    ProductEnvironment = "<ProductEnvironment>"
    CapabilityTeam = "<CapabilityTeam>"
}

if ($rg = Get-AzResourceGroup -Name $resourceGroupName) {
  $rg.Tags = $tags
  Set-AzResourceGroup -ResourceGroupName $resourceGroupName -Tag $rg.Tags

  Write-Output "Resource group already exists, updating tags."
} else {
  New-AzResourceGroup -Name $resourceGroupName -Location $location -Tag $tags
}