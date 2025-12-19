import { useState } from 'react'
import { useWorkspaceTypes } from '../hooks/useData'
import { api, endpoints } from '../lib/supabase'
import '../styles/Table.css'

export default function WorkspaceTypes() {
  const { data: types, loading } = useWorkspaceTypes()
  const [showForm, setShowForm] = useState(false)
  const [formData, setFormData] = useState({
    name: '',
    description: '',
    price_per_hour: '',
  })

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    try {
      await api.post(endpoints.workspaceTypes, {
        name: formData.name,
        description: formData.description,
      })
      setFormData({ name: '', description: '', price_per_hour: '' })
      setShowForm(false)
      window.location.reload()
    } catch (error) {
      console.error('Error creating workspace type:', error)
    }
  }

  const handleDelete = async (id: number) => {
    if (!confirm('Are you sure you want to delete this workspace type?')) return
    try {
      await api.delete(`${endpoints.workspaceTypes}/${id}`)
      window.location.reload()
    } catch (error) {
      console.error('Error deleting workspace type:', error)
    }
  }

  if (loading) {
    return <div className="page"><p>Loading...</p></div>
  }

  return (
    <div className="page">
      <div className="page-header">
        <h1>Workspace Types</h1>
        <button className="btn btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancel' : 'Add Type'}
        </button>
      </div>

      {showForm && (
        <form className="form" onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Type Name"
            value={formData.name}
            onChange={(e) => setFormData({ ...formData, name: e.target.value })}
            required
          />
          <textarea
            placeholder="Description"
            value={formData.description}
            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
          />
          <input
            type="number"
            placeholder="Price Per Hour"
            step="0.01"
            value={formData.price_per_hour}
            onChange={(e) => setFormData({ ...formData, price_per_hour: e.target.value })}
            required
          />
          <button type="submit" className="btn btn-success">Create</button>
        </form>
      )}

      <table className="data-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Description</th>
            <th>Price/Hour</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {types.map((type: any) => (
            <tr key={type.id}>
              <td>{type.id}</td>
              <td>{type.name}</td>
              <td>{type.description}</td>
                <td>{type.pricePerHour ? `$${type.pricePerHour}` : 'N/A'}</td>
              <td>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(type.id)}>
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
