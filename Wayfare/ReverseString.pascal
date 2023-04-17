function code(a: char[], length: integer): char[]
  for i:=1 to length:
    aux := a[i]
    a[i] := a[length - i + 1]
    a[length - i + 1] := aux
  end_for

  return a
end_function