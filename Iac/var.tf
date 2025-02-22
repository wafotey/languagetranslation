variable "env_id" {
  description = "This is an environment variable."
  type        = string
  default     = "dev"
}
variable "subscription_id" {
  description = "Azure subscription id"
  type        = string
  default     = "0e4f3999-feb9-4ab9-9bb4-2271f5965d82"
}
variable "src_key" {
  description = "Azure subscription id"
  type        = string
  default     = "terraform"
}

variable "sql_password" {
  description = "Sql password"
  type        = string
}
