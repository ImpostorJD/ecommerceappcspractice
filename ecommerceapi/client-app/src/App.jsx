import { useState, useEffect } from 'react'

import './App.css'

function App() {

  
  const testApi = async () => {
    const test = await fetch('/api/weatherforecast')
    console.log(await test.json());
  }
  useEffect(()=> {
    testApi();
  }, [])

  return (
    <>
     
    </>
  )
}

export default App
