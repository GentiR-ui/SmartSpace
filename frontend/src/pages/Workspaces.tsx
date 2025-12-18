import { useState } from 'react'
import { useWorkspaces, useLocations, useWorkspaceTypes } from '../hooks/useData'
import { api, endpoints } from '../lib/supabase'
import type { Workspace } from '../lib/models'
import '../styles/Table.css'

export default function Workspaces() {
  const { data: workspaces, loading: loadingWorkspaces } = useWorkspaces()
  const { data: locations } = useLocations()
  const { data: types } = useWorkspaceTypes()
  const [showForm, setShowForm] = useState(false)
  const [formData, setFormData] = useState<Partial<Workspace>>({})

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    if (!formData.name || !formData.locationId || !formData.workspaceTypeId) {
      alert('Please fill in all required fields')
      return
    }
    try {
      const response = await api.post(endpoints.workspaces, formData)
      console.log('Workspace created:', response.data)
      setFormData({})
      setShowForm(false)
      window.location.reload()
    } catch (error: any) {
      console.error('Error creating workspace:', error.response?.data || error.message)
      alert(`Error: ${error.response?.data?.message || error.message}`)
    }
  }

  const handleDelete = async (id: number) => {
    if (!confirm('Are you sure you want to delete this workspace?')) return
    try {
      await api.delete(`${endpoints.workspaces}/${id}`)
      window.location.reload()
    } catch (error) {
      console.error('Error deleting workspace:', error)
    }
  }

  if (loadingWorkspaces) {
    return <div className="page"><p>Loading...</p></div>
  }

  return (
    <div className="page">
      <div className="page-header">
        <h1>Workspaces</h1>
        <button className="btn btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancel' : 'Add Workspace'}
        </button>
      </div>

      {showForm && (
        <form className="form" onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Workspace Name"
            value={formData.name}
            onChange={(e) => setFormData({ ...formData, name: e.target.value })}
            required
          />
          <textarea
            placeholder="Description"
            value={formData.description}
            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
          />
          <select
            value={(formData.locationId as number) ?? ''}
            onChange={(e) => setFormData({ ...formData, locationId: parseInt(e.target.value) })}
            required
          >
            <option value="">Select Location</option>
            {locations.map((loc: any) => (
              <option key={loc.id} value={loc.id}>{loc.city ?? loc.address ?? `Location ${loc.id}`}</option>
            ))}
          </select>
          <select
            value={(formData.workspaceTypeId as number) ?? ''}
            onChange={(e) => setFormData({ ...formData, workspaceTypeId: parseInt(e.target.value) })}
            required
          >
            <option value="">Select Workspace Type</option>
            {types.map((type: any) => (
              <option key={type.id} value={type.id}>{type.name}</option>
            ))}
          </select>
          <button type="submit" className="btn btn-success">Create</button>
        </form>
      )}

      <table className="data-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Description</th>
            <th>Location</th>
            <th>Type</th>
            <th>Active</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {workspaces.map((workspace: any) => (
            <tr key={workspace.id}>
              <td>{workspace.id}</td>
              <td>{workspace.name}</td>
              <td>{workspace.description}</td>
              <td>{workspace.locationId ?? 'N/A'}</td>
              <td>{workspace.workspaceTypeId ?? 'N/A'}</td>
              <td>{workspace.is_active ? 'Yes' : 'No'}</td>
              <td>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(workspace.id)}>
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
