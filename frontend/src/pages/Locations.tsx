import { useState } from 'react'
import { useLocations } from '../hooks/useData'
import { api, endpoints } from '../lib/supabase'
import '../styles/Table.css'

export default function Locations() {
  const { data: locations, loading } = useLocations()
  const [showForm, setShowForm] = useState(false)
  const [formData, setFormData] = useState({
    name: '',
    address: '',
    city: '',
    state: '',
    zip_code: '',
    country: '',
    latitude: '',
    longitude: '',
  })

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    try {
      const response = await api.post(endpoints.locations, {
        address: formData.address,
        city: formData.city,
        country: formData.country,
        postalCode: formData.zip_code,
      })
      console.log('Location created:', response.data)
      setFormData({ name: '', address: '', city: '', state: '', zip_code: '', country: '', latitude: '', longitude: '' })
      setShowForm(false)
      window.location.reload()
    } catch (error: any) {
      console.error('Error creating location:', error.response?.data || error.message)
      alert(`Error: ${error.response?.data?.message || error.message}`)
    }
  }

  const handleDelete = async (id: number) => {
    if (!confirm('Are you sure you want to delete this location?')) return
    try {
      await api.delete(`${endpoints.locations}/${id}`)
      window.location.reload()
    } catch (error) {
      console.error('Error deleting location:', error)
    }
  }

  if (loading) {
    return <div className="page"><p>Loading...</p></div>
  }

  return (
    <div className="page">
      <div className="page-header">
        <h1>Locations</h1>
        <button className="btn btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancel' : 'Add Location'}
        </button>
      </div>

      {showForm && (
        <form className="form" onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Location Name"
            value={formData.name}
            onChange={(e) => setFormData({ ...formData, name: e.target.value })}
            required
          />
          <input
            type="text"
            placeholder="Address"
            value={formData.address}
            onChange={(e) => setFormData({ ...formData, address: e.target.value })}
            required
          />
          <input
            type="text"
            placeholder="City"
            value={formData.city}
            onChange={(e) => setFormData({ ...formData, city: e.target.value })}
            required
          />
          <input
            type="text"
            placeholder="State"
            value={formData.state}
            onChange={(e) => setFormData({ ...formData, state: e.target.value })}
            required
          />
          <input
            type="text"
            placeholder="Zip Code"
            value={formData.zip_code}
            onChange={(e) => setFormData({ ...formData, zip_code: e.target.value })}
            required
          />
          <input
            type="text"
            placeholder="Country"
            value={formData.country}
            onChange={(e) => setFormData({ ...formData, country: e.target.value })}
            required
          />
          <input
            type="number"
            placeholder="Latitude"
            step="0.000001"
            value={formData.latitude}
            onChange={(e) => setFormData({ ...formData, latitude: e.target.value })}
          />
          <input
            type="number"
            placeholder="Longitude"
            step="0.000001"
            value={formData.longitude}
            onChange={(e) => setFormData({ ...formData, longitude: e.target.value })}
          />
          <button type="submit" className="btn btn-success">Create</button>
        </form>
      )}

      <table className="data-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Address</th>
            <th>City</th>
            <th>Country</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {locations.map((location: any) => (
            <tr key={location.id}>
              <td>{location.id}</td>
              <td>{location.address}</td>
              <td>{location.city}</td>
              <td>{location.country}</td>
              <td>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(location.id)}>
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
