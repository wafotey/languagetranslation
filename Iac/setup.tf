terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.16.0"
    }
  }

  required_version = ">= 1.0"
}

provider "azurerm" {
  features {}

  # Authenticate using the Azure CLI (if logged in)
  # You can skip the `client_id`, `client_secret`, `tenant_id`, and `subscription_id` if using Azure CLI or Managed Identity
  subscription_id = var.subscription_id
}
