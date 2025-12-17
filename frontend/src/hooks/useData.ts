import { useState, useEffect } from 'react'
import { api, endpoints } from '../lib/supabase'
import type { Workspace, Location, WorkspaceType, Reservation, Customer, Payment } from '../lib/models'

interface UseDataOptions {
  enabled?: boolean
}

export function useWorkspaces(options: UseDataOptions = {}) {
  const [data, setData] = useState<Workspace[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    if (options.enabled === false) return

    const fetchData = async () => {
      setLoading(true)
      try {
        const { data: workspaces } = await api.get<Workspace[]>(endpoints.workspaces)
        setData(workspaces || [])
        setError(null)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred')
        setData([])
      } finally {
        setLoading(false)
      }
    }

    fetchData()
  }, [options.enabled])

  return { data, loading, error }
}

export function useLocations(options: UseDataOptions = {}) {
  const [data, setData] = useState<Location[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    if (options.enabled === false) return

    const fetchData = async () => {
      setLoading(true)
      try {
        const { data: locations } = await api.get<Location[]>(endpoints.locations)
        setData(locations || [])
        setError(null)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred')
        setData([])
      } finally {
        setLoading(false)
      }
    }

    fetchData()
  }, [options.enabled])

  return { data, loading, error }
}

export function useWorkspaceTypes(options: UseDataOptions = {}) {
  const [data, setData] = useState<WorkspaceType[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    if (options.enabled === false) return

    const fetchData = async () => {
      setLoading(true)
      try {
        const { data: types } = await api.get<WorkspaceType[]>(endpoints.workspaceTypes)
        setData(types || [])
        setError(null)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred')
        setData([])
      } finally {
        setLoading(false)
      }
    }

    fetchData()
  }, [options.enabled])

  return { data, loading, error }
}

export function useReservations(options: UseDataOptions = {}) {
  const [data, setData] = useState<Reservation[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    if (options.enabled === false) return

    const fetchData = async () => {
      setLoading(true)
      try {
        const { data: reservations } = await api.get<Reservation[]>(endpoints.reservations)
        setData(reservations || [])
        setError(null)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred')
        setData([])
      } finally {
        setLoading(false)
      }
    }

    fetchData()
  }, [options.enabled])

  return { data, loading, error }
}

export function useCustomers(options: UseDataOptions = {}) {
  const [data, setData] = useState<Customer[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    if (options.enabled === false) return

    const fetchData = async () => {
      setLoading(true)
      try {
        const { data: customers } = await api.get<Customer[]>(endpoints.customers)
        setData(customers || [])
        setError(null)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred')
        setData([])
      } finally {
        setLoading(false)
      }
    }

    fetchData()
  }, [options.enabled])

  return { data, loading, error }
}

export function usePayments(options: UseDataOptions = {}) {
  const [data, setData] = useState<Payment[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    if (options.enabled === false) return

    const fetchData = async () => {
      setLoading(true)
      try {
        const { data: payments } = await api.get<Payment[]>(endpoints.payments)
        setData(payments || [])
        setError(null)
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred')
        setData([])
      } finally {
        setLoading(false)
      }
    }

    fetchData()
  }, [options.enabled])

  return { data, loading, error }
}
