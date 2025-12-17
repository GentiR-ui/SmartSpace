import { useEffect, useState } from 'react'
import { api, endpoints } from '../lib/supabase'
import '../styles/Dashboard.css'

interface Stats {
  workspaces: number
  reservations: number
  customers: number
  payments: number
}

export default function Dashboard() {
  const [stats, setStats] = useState<Stats>({ workspaces: 0, reservations: 0, customers: 0, payments: 0 })
  const [loading, setLoading] = useState(true)

  const fetchStats = async () => {
    setLoading(true)
    try {
      const [workspacesRes, reservationsRes, customersRes, paymentsRes] = await Promise.all([
        api.get(endpoints.workspaces),
        api.get(endpoints.reservations),
        api.get(endpoints.customers),
        api.get(endpoints.payments),
      ])

      setStats({
        workspaces: (workspacesRes.data?.length) ?? 0,
        reservations: (reservationsRes.data?.length) ?? 0,
        customers: (customersRes.data?.length) ?? 0,
        payments: (paymentsRes.data?.length) ?? 0,
      })
    } catch (error) {
      console.error('Failed to fetch stats:', error)
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    fetchStats()
  }, [])

  if (loading) {
    return <div className="page"><p>Loading...</p></div>
  }

  return (
    <div className="page">
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '2rem' }}>
        <h1>Dashboard</h1>
        <button className="btn btn-primary" onClick={fetchStats}>
          Refresh Stats
        </button>
      </div>
      <div className="stats-grid">
        <div className="stat-card">
          <h3>Workspaces</h3>
          <p className="stat-number">{stats.workspaces}</p>
        </div>
        <div className="stat-card">
          <h3>Reservations</h3>
          <p className="stat-number">{stats.reservations}</p>
        </div>
        <div className="stat-card">
          <h3>Customers</h3>
          <p className="stat-number">{stats.customers}</p>
        </div>
        <div className="stat-card">
          <h3>Payments</h3>
          <p className="stat-number">{stats.payments}</p>
        </div>
      </div>
    </div>
  )
}
