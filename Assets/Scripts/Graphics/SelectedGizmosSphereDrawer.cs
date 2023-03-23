namespace Graphics
{
    public class SelectedGizmosSphereDrawer : SphereDrawer
    {
        private void OnDrawGizmosSelected()
        {
            DrawSphere();
        }
    }
}
