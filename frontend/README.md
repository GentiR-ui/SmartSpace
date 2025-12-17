# SmartSpace Frontend

A modern React + TypeScript + Vite frontend for managing workspace reservations, customers, and payments.

## Features

- Dashboard with statistics overview
- Workspace management (CRUD operations)
- Location management
- Workspace type management
- Reservation management with status tracking
- Customer management
- Payment processing and tracking
- Real-time data synchronization with Supabase
- Responsive design for mobile and desktop

## Prerequisites

- Node.js 18+
- npm or yarn

## Installation

1. Navigate to the frontend directory:
```bash
cd frontend
```

2. Install dependencies:
```bash
npm install
```

3. Create `.env` file from `.env.example`:
```bash
cp .env.example .env
```

4. Add your Supabase credentials to `.env`:
```
VITE_SUPABASE_URL=https://your-project.supabase.co
VITE_SUPABASE_ANON_KEY=your-anon-key
```

## Development

Start the development server:
```bash
npm run dev
```

The app will open at http://localhost:5173

## Build

Build for production:
```bash
npm run build
```

Output will be in the `dist` folder.

## Project Structure

```
frontend/
├── src/
│   ├── pages/           # Page components
│   │   ├── Dashboard.tsx
│   │   ├── Workspaces.tsx
│   │   ├── Locations.tsx
│   │   ├── WorkspaceTypes.tsx
│   │   ├── Reservations.tsx
│   │   ├── Customers.tsx
│   │   └── Payments.tsx
│   ├── hooks/           # Custom React hooks
│   │   └── useData.ts
│   ├── styles/          # CSS files
│   ├── lib/             # Utilities
│   │   └── supabase.ts
│   ├── App.tsx
│   └── main.tsx
├── index.html
├── tsconfig.json
├── vite.config.ts
└── package.json
```

## Key Technologies

- **React 18** - UI library
- **TypeScript** - Type safety
- **Vite** - Fast build tool
- **React Router** - Navigation
- **Supabase JS Client** - Database and API

## API Integration

The frontend connects to Supabase PostgreSQL database for:
- Reading and writing workspace data
- Managing reservations
- Processing payments
- Tracking customers
- Real-time updates

All data operations use the Supabase client which provides:
- Type-safe queries
- Real-time subscriptions
- Authentication support
- RLS (Row Level Security)

## Styling

The app uses vanilla CSS with:
- CSS Variables for theming
- Mobile-first responsive design
- Smooth transitions and animations
- Accessible color contrasts

## Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

## Environment Variables

Required environment variables:
- `VITE_SUPABASE_URL` - Your Supabase project URL
- `VITE_SUPABASE_ANON_KEY` - Your Supabase anonymous API key

Get these from your Supabase project settings.
