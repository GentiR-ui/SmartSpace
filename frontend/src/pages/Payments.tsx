import { useState } from 'react'
import { usePayments, useReservations } from '../hooks/useData'
import { api, endpoints } from '../lib/supabase'
import '../styles/Table.css'

export default function Payments() {
  const { data: payments, loading } = usePayments()
  const { data: reservations } = useReservations()
  const [showForm, setShowForm] = useState(false)
  const [formData, setFormData] = useState({
    reservation_id: '',
    amount: '',
    status: 'Pending',
    payment_method: '',
    transaction_id: '',
  })

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    try {
      await api.post(endpoints.payments, {
        reservationId: parseInt(formData.reservation_id),
        amount: parseFloat(formData.amount),
        status: formData.status,
      })
      setFormData({ reservation_id: '', amount: '', status: 'Pending', payment_method: '', transaction_id: '' })
      setShowForm(false)
      window.location.reload()
    } catch (error) {
      console.error('Error creating payment:', error)
    }
  }

  const handleStatusChange = async (id: number, newStatus: string) => {
    try {
      await api.patch(`${endpoints.payments}/${id}`, { status: newStatus })
      window.location.reload()
    } catch (error) {
      console.error('Error updating payment:', error)
    }
  }

  const handleDelete = async (id: number) => {
    if (!confirm('Are you sure you want to delete this payment?')) return
    try {
      await api.delete(`${endpoints.payments}/${id}`)
      window.location.reload()
    } catch (error) {
      console.error('Error deleting payment:', error)
    }
  }

  if (loading) {
    return <div className="page"><p>Loading...</p></div>
  }

  return (
    <div className="page">
      <div className="page-header">
        <h1>Payments</h1>
        <button className="btn btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancel' : 'New Payment'}
        </button>
      </div>

      {showForm && (
        <form className="form" onSubmit={handleSubmit}>
          <select
            value={formData.reservation_id}
            onChange={(e) => setFormData({ ...formData, reservation_id: e.target.value })}
            required
          >
            <option value="">Select Reservation</option>
            {reservations.map((res: any) => (
              <option key={res.id} value={res.id}>
                Reservation #{res.id} - {res.workspace?.name}
              </option>
            ))}
          </select>
          <input
            type="number"
            placeholder="Amount"
            step="0.01"
            value={formData.amount}
            onChange={(e) => setFormData({ ...formData, amount: e.target.value })}
            required
          />
          <select
            value={formData.payment_method}
            onChange={(e) => setFormData({ ...formData, payment_method: e.target.value })}
            required
          >
            <option value="">Select Payment Method</option>
            <option value="Credit Card">Credit Card</option>
            <option value="Debit Card">Debit Card</option>
            <option value="Bank Transfer">Bank Transfer</option>
            <option value="Cash">Cash</option>
          </select>
          <input
            type="text"
            placeholder="Transaction ID"
            value={formData.transaction_id}
            onChange={(e) => setFormData({ ...formData, transaction_id: e.target.value })}
          />
          <button type="submit" className="btn btn-success">Create</button>
        </form>
      )}

      <table className="data-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Reservation</th>
            <th>Amount</th>
            <th>Method</th>
            <th>Status</th>
            <th>Created At</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {payments.map((payment: any) => (
            <tr key={payment.id}>
              <td>{payment.id}</td>
              <td>{payment.reservationId ?? 'N/A'}</td>
              <td>${payment.amount}</td>
              <td>{payment.paymentMethod || '-'}</td>
              <td>
                <select
                  value={payment.status || 'Pending'}
                  onChange={(e) => handleStatusChange(payment.id, e.target.value)}
                  className="status-select"
                >
                  <option value="Pending">Pending</option>
                  <option value="Completed">Completed</option>
                  <option value="Failed">Failed</option>
                </select>
              </td>
              <td>{payment.paymentDate ? new Date(payment.paymentDate).toLocaleDateString() : 'N/A'}</td>
              <td>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(payment.id)}>
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}
