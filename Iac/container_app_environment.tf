resource "azurerm_container_app_environment" "container_app_environment" {
  name                       = "DeptDevContainerAppEnvironmentTranslation"
  location                   = azurerm_resource_group.resource-group-translation.location
  resource_group_name        = azurerm_resource_group.resource-group-translation.name
  log_analytics_workspace_id = azurerm_log_analytics_workspace.log_analytics_workspace.id
  
    tags = {
    environment = "Development"  # Example tag: key = "Environment", value = "Development"
    src = var.src_key
  }
}