resource "azurerm_log_analytics_workspace" "log_analytics_workspace" {
  name                = "dept-dev-log-analytics-workspace-translation"
  location            = azurerm_resource_group.resource-group-translation.location
  resource_group_name = azurerm_resource_group.resource-group-translation.name
  sku                 = "PerGB2018"
  retention_in_days   = 30
}