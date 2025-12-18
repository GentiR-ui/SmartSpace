import { useState } from 'react'
import { useReservations, useWorkspaces, useCustomers } from '../hooks/useData'
import { api, endpoints } from '../lib/supabase'
import '../styles/Table.css'

export default function Reservations() {
  const { data: reservations, loading } = useReservations()
  const { data: workspaces } = useWorkspaces()
  const { data: customers } = useCustomers()
  const [showForm, setShowForm] = useState(false)
  const [formData, setFormData] = useState({
    workspace_id: '',
    customer_id: '',
    start_time: '',
    end_time: '',
    status: 'Pending',
  })

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    try {
      await api.post(endpoints.reservations, {
        workspaceId: parseInt(formData.workspace_id),
        customerId: parseInt(formData.customer_id),
        startTime: formData.start_time,
        endTime: formData.end_time,
        status: formData.status,
      })
      setFormData({ workspace_id: '', customer_id: '', start_time: '', end_time: '', status: 'Pending' })
      setShowForm(false)
      window.location.reload()
    } catch (error) {
      console.error('Error creating reservation:', error)
    }
  }

  const handleStatusChange = async (id: number, newStatus: string) => {
    try {
      await api.patch(`${endpoints.reservations}/${id}`, { status: newStatus })
      window.location.reload()
    } catch (error) {
      console.error('Error updating reservation:', error)
    }
  }

  const handleDelete = async (id: number) => {
    if (!confirm('Are you sure you want to delete this reservation?')) return
    try {
      await api.delete(`${endpoints.reservations}/${id}`)
      window.location.reload()
    } catch (error) {
      console.error('Error deleting reservation:', error)
    }
  }

  if (loading) {
    return <div className="page"><p>Loading...</p></div>
  }

  return (
    <div className="page">
      <div className="page-header">
        <h1>Reservations</h1>
        <button className="btn btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancel' : 'New Reservation'}
        </button>
      </div>

      {showForm && (
        <form className="form" onSubmit={handleSubmit}>
          <select
            value={formData.workspace_id}
            onChange={(e) => setFormData({ ...formData, workspace_id: e.target.value })}
            required
          >
            <option value="">Select Workspace</option>
            {workspaces.map((ws: any) => (
              <option key={ws.id} value={ws.id}>{ws.name}</option>
            ))}
          </select>
          <select
            value={formData.customer_id}
            onChange={(e) => setFormData({ ...formData, customer_id: e.target.value })}
            required
          >
            <option value="">Select Customer</option>
            {customers.map((customer: any) => (
              <option key={customer.id} value={customer.id}>{customer.name} ({customer.email})</option>
            ))}
          </select>
          <input
            type="datetime-local"
            value={formData.start_time}
            onChange={(e) => setFormData({ ...formData, start_time: e.target.value })}
            required
          />
          <input
            type="datetime-local"
            value={formData.end_time}
            onChange={(e) => setFormData({ ...formData, end_time: e.target.value })}
            required
          />
          <button type="submit" className="btn btn-success">Create</button>
        </form>
      )}

      <table className="data-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Workspace</th>
            <th>Customer</th>
            <th>Start Time</th>
            <th>End Time</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {reservations.map((res: any) => {
            const workspace = workspaces.find((w: any) => w.id === res.workspaceId)
            const customer = customers.find((c: any) => c.id === res.customerId)
            return (
              <tr key={res.id}>
                <td>{res.id}</td>
                <td>{workspace?.name || `Workspace ${res.workspaceId}`}</td>
                <td>{customer?.name || `Customer ${res.customerId}`}</td>
                <td>{res.startTime ? new Date(res.startTime).toLocaleString() : 'N/A'}</td>
                <td>{res.endTime ? new Date(res.endTime).toLocaleString() : 'N/A'}</td>
                <td>
                  <select
                    value={res.status || 'Pending'}
                    onChange={(e) => handleStatusChange(res.id, e.target.value)}
                    className="status-select"
                  >
                    <option value="Pending">Pending</option>
                    <option value="Confirmed">Confirmed</option>
                    <option value="Cancelled">Cancelled</option>
                  </select>
                </td>
                <td>
                  <button className="btn btn-danger btn-sm" onClick={() => handleDelete(res.id)}>
                    Delete
                  </button>
                </td>
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>
  )
}
