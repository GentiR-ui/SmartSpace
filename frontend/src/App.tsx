import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'
import Dashboard from './pages/Dashboard'
import Workspaces from './pages/Workspaces'
import Reservations from './pages/Reservations'
import Locations from './pages/Locations'
import WorkspaceTypes from './pages/WorkspaceTypes'
import Customers from './pages/Customers'
import Payments from './pages/Payments'
import './styles/App.css'

function App() {
  return (
    <Router>
      <div className="app">
        <nav className="navbar">
          <div className="navbar-brand">
            <h1>SmartSpace</h1>
          </div>
          <ul className="navbar-menu">
            <li><Link to="/">Dashboard</Link></li>
            <li><Link to="/workspaces">Workspaces</Link></li>
            <li><Link to="/locations">Locations</Link></li>
            <li><Link to="/workspace-types">Workspace Types</Link></li>
            <li><Link to="/reservations">Reservations</Link></li>
            <li><Link to="/customers">Customers</Link></li>
            <li><Link to="/payments">Payments</Link></li>
          </ul>
        </nav>

        <main className="main-content">
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/workspaces" element={<Workspaces />} />
            <Route path="/locations" element={<Locations />} />
            <Route path="/workspace-types" element={<WorkspaceTypes />} />
            <Route path="/reservations" element={<Reservations />} />
            <Route path="/customers" element={<Customers />} />
            <Route path="/payments" element={<Payments />} />
          </Routes>
        </main>
      </div>
    </Router>
  )
}

export default App
