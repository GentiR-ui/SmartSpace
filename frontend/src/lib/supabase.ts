import axios from 'axios'

export const api = axios.create({
  baseURL: '/api',
  headers: { 'Content-Type': 'application/json' }
})

export const endpoints = {
  workspaces: '/workspaces',
  locations: '/locations',
  workspaceTypes: '/workspacetypes',
  reservations: '/reservations',
  customers: '/customers',
  payments: '/payments',
  reviews: '/reviews'
}
